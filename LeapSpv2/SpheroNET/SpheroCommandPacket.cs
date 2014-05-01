using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{

    public class SpheroCommandPacket: SpheroPacket
    {

        public byte DeviceId
        { 
            get 
            { 
                return _data[2]; 
            } 
            set 
            { 
                _data[2] = value; 
                UpdateChecksum(); 
            } 
        }
        
        public byte CommandId
        { 
            get 
            { 
                return _data[3]; 
            } 
            set 
            { 
                _data[3] = value; 
                UpdateChecksum(); 
            } 
        }

        public byte SequenceNumber
        { 
            get 
            { 
                return _data[4]; 
            } 
            set 
            { 
                _data[4] = value; 
                UpdateChecksum(); 
            } 
        }

        public byte DataLength
        { 
            get 
            { 
                return _data[5]; 
            } 
            set 
            { 
                _data[5] = value; UpdateChecksum(); 
            } 
        }        

        public SpheroCommandPacket(byte deviceId, byte commandId, 
            byte sequenceNumber, byte[] data): base()
        {
            List<byte> list = new List<byte>();
            list.AddRange(_data);
            list.AddRange(new Byte[] { deviceId, commandId, sequenceNumber });

            if (data != null)
            {
                list.Add((byte)(data.Length + 1));
                list.AddRange(data);
            }
            else
            {
                list.Add(0x01);
            }

            list.Add(0xFF); // Placeholder for checksum
            _data = list.ToArray();
            UpdateChecksum();
          
        }
    }
}
