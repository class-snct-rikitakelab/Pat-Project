using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace SpheroNET
{
    public class Sphero
    {

        private byte _nextSequenceNumber = 0;
        private int _numberOfPacketsToLog;

        public SpheroListener Listener
        {
            get; private set;
        }

        public NetworkStream Stream
        {
            get; private set;
        }

        public List<SpheroCommandPacket> SentPackets
        {
            get; private set;
        }

        public Sphero(NetworkStream stream, int numberOfPacketsToLog = 1000)
        {
            Stream = stream;
            Listener = new SpheroListener(this);
            SentPackets = new List<SpheroCommandPacket>();
            _numberOfPacketsToLog = numberOfPacketsToLog;
        }
        
        public void SendPacket(SpheroCommandPacket packet)
        {
            // Each packet we send has an updated sequence number.
            packet.SequenceNumber = GetNextSequenceNumber();
            RegisterSentPacket(packet);
            Stream.Write(packet.Data, 0, packet.Data.Length);
        }


        private void RegisterSentPacket(SpheroCommandPacket packet)
        {
            SentPackets.Add(packet);
            if (SentPackets.Count > _numberOfPacketsToLog) 
                SentPackets.RemoveAt(0);
        }

        public void EraseOrbBasicStorage(StorageArea area)
        {
            SendPacket(SpheroCommandPacketFactory.EraseOrbBasicStorage(area));
        }

        public void SendOrbBasicProgram(StorageArea area, IEnumerable<string> programLines)
        {
            foreach (var line in programLines)
            {
                AppendOrbBasicFragment(area, line);
            }
        }

        public void Roll(int speed, int heading, int value)
        {
            SendPacket(SpheroCommandPacketFactory.Roll(speed, heading, value));
        }

        public void SetBackLEDOutput(int bright)
        {
            SendPacket(SpheroCommandPacketFactory.SetBackLEDOutput(bright));
        }

        public void AppendOrbBasicFragment(StorageArea area, string fragment)
        {
            SendPacket(SpheroCommandPacketFactory.AppendOrbBasicFragment(area, fragment));
        }

        public void ExecuteOrbBasicProgram(StorageArea area, UInt16 fromLine)
        {
            SendPacket(SpheroCommandPacketFactory.ExecuteOrbBasicProgram(area,fromLine));
        }

        public void AbortOrbBasicProgram()
        {
             SendPacket(SpheroCommandPacketFactory.AbortOrbBasicProgram());
        }

        public void SetRGBLEDOutput(byte r, byte g, byte b)
        {
             SendPacket(SpheroCommandPacketFactory.SetRGBLEDOutput(r,g,b));
        }

        public void PerformLevelOneDiagnostics()
        {
             SendPacket(SpheroCommandPacketFactory.PerformLevelOneDiagnostics());
        }

        public void Sleep()
        {
            SendPacket(SpheroCommandPacketFactory.Sleep());
        }

        public byte GetNextSequenceNumber()
        {
            byte sequenceNumber = _nextSequenceNumber;
            _nextSequenceNumber = 
                (byte)(_nextSequenceNumber == 0xFF ? 
                0 : ++_nextSequenceNumber);
            return sequenceNumber;
        }


    }
}
