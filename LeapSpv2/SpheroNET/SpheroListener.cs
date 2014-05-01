using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace SpheroNET
{

    public class PacketReadyEventArgs : EventArgs
    {

        public PacketReadyEventArgs(SpheroPacket packet)
        {
            Packet = packet;
        }

        public SpheroPacket Packet
        {
            get;
            private set;
        }

    }
    
    public class SpheroListener
    {
        public readonly object SyncRoot = new object();
        private readonly List<byte> _buffer;
        private byte[] _rawBuffer;
        private readonly NetworkStream _stream;
        private readonly int _numberOfPacketsToLog;

        public delegate void PacketReadyEventHandler(object sender, PacketReadyEventArgs e);

        public event PacketReadyEventHandler PacketReady;

        public List<SpheroResponsePacket> ResponsePackets { get; private set; }

        public List<SpheroAsyncPacket> AsyncPackets { get; private set; } 

        public SpheroPacket LastPacket
        {
            get { return (ResponsePackets != null && ResponsePackets.Count > 0) ? ResponsePackets[ResponsePackets.Count-1] : null; }
        }

        public SpheroListener(Sphero sphero, int numberOfPacketsToLog = 1000)
        {
            ResponsePackets = new List<SpheroResponsePacket>();
            AsyncPackets = new List<SpheroAsyncPacket>();
            _buffer = new List<byte>();
            _stream = sphero.Stream;
            _numberOfPacketsToLog = numberOfPacketsToLog;
            Listen();
        }

        private void RegisterReceivedPacket(SpheroPacket packet)
        {
            if (packet is SpheroResponsePacket)
            {
                ResponsePackets.Add(packet as SpheroResponsePacket);
                if (ResponsePackets.Count > _numberOfPacketsToLog)
                    ResponsePackets.RemoveAt(0);
            }
            else if (packet is SpheroAsyncPacket)
            {
                AsyncPackets.Add(packet as SpheroAsyncPacket);
                if (AsyncPackets.Count > _numberOfPacketsToLog)
                    AsyncPackets.RemoveAt(0);
            }
            else
            {
                throw new Exception("Unknown packet type. This should not happen.");
            }
        }

        private void Listen()
        {
            if (_stream.CanRead)
            {
                _rawBuffer = new byte[1024];
                _stream.BeginRead(_rawBuffer, 0, _rawBuffer.Length, Listener, _stream);
            }
            else
            {
                throw new Exception("Sorry.  You cannot read from this NetworkStream.");
            }
        }

        private void Listener(IAsyncResult ar)
        {
            try
            {
                var stream = (NetworkStream)ar.AsyncState;
                int bytesRead = stream.EndRead(ar);
                AddData(_rawBuffer.Take(bytesRead).ToArray());
                _rawBuffer = new byte[1024];
                stream.BeginRead(_rawBuffer, 0, _rawBuffer.Length, Listener, stream);
            }
            catch
            {
                // TODO: A problem for another day. 
                // Dying silently for now. 
            }
        }

        private void AddData(byte[] data)
        {
            SpheroPacket packet = AssemblePacket(data);
            if (packet != null)
            {
                lock (SyncRoot)
                {
                    RegisterReceivedPacket(packet);
                }
                OnPacketReady(new PacketReadyEventArgs(packet));
            }
        }

        private SpheroPacket AssemblePacket(byte[] data)
        {
            const int preambleSize = 5;
            _buffer.AddRange(data);

            // Remove any leading garbage until 0xFF is found 
            // (presumably the beginning of a packet).
            bool packetFound = false;
            for (int i = 0; i < _buffer.Count; i++)
            {
                if (_buffer[i] == 0xFF)
                {
                    _buffer.RemoveRange(0, i);
                    packetFound = true;
                    break;  
                }
            }

            // Clear buffer and return null 
            // if none was found.
            if (!packetFound)
            {
                _buffer.Clear();
                return null;
            }

            // When we have accumulated 6 bytes 
            // or more beginning with 0xFF.
            if (_buffer.Count > 5)
            {
                byte type = _buffer[1];
                // This is a synchronous response.
                if (type == 0xFF)
                {
                    // What is the size of the packet?
                    byte dlen = _buffer[4];
                    int plen = dlen + preambleSize;
                    // If we have enough data for an entire packet.
                    if (_buffer.Count >= plen)
                    { 
                        // Remove the data from the buffer, put 
                        // it into a packet, and return it.
                        byte[] packetData = _buffer.Take(plen).ToArray();
                        _buffer.RemoveRange(0, plen);
                        return new SpheroResponsePacket(packetData);;
                    }
                } // This is an asynchronous response.
                else if (type == 0xFE)
                {
                    int dlenMsb = _buffer[3];
                    int dlenLsb = _buffer[4];
                    int plen = ((dlenMsb << 8) | dlenLsb) + preambleSize;
                     // If we have enough data for an entire packet.
                    if (_buffer.Count >= plen)
                    {
                        // Remove the data from the buffer, put 
                        // it into a packet, and return it.
                        byte[] packetData = _buffer.Take(plen).ToArray();
                        _buffer.RemoveRange(0, plen);
                        return new SpheroAsyncPacket(packetData);
                    }
                }

            }
           
            return null;
        }

        public void Clear()
        {
            ResponsePackets.Clear();
            AsyncPackets.Clear();
        }

        public IEnumerable<SpheroResponsePacket> GetLastResponsePackets(int number)
        {
            var result = new SpheroResponsePacket[0];
            int lastIndex = ResponsePackets.Count - 1;
            lock (SyncRoot)
            {
                if (ResponsePackets.Count == 0) return result;
                if (ResponsePackets.Count < number) number = ResponsePackets.Count;
                result = new SpheroResponsePacket[number];
                for (int i = lastIndex, j = number-1; i > lastIndex - number; i--, j--)
                {
                    result[j] = ResponsePackets[i];
                }
            }
            return result;
        }

        public IEnumerable<SpheroAsyncPacket> GetLastAsyncPackets(int number)
        {
            var result = new SpheroAsyncPacket[0];
            int lastIndex = AsyncPackets.Count - 1;
            lock (SyncRoot)
            {
                if (AsyncPackets.Count == 0) return result;
                if (AsyncPackets.Count < number) number = AsyncPackets.Count;
                result = new SpheroAsyncPacket[number];
                for (int i = lastIndex, j = number - 1; i > lastIndex - number; i--, j--)
                {
                    result[j] = AsyncPackets[i];
                }
            }
            return result;
        }

        protected virtual void OnPacketReady(PacketReadyEventArgs e)
        {
            if (PacketReady != null)
                PacketReady(this, e);
        }

    }
}
