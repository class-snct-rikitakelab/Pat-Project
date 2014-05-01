using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{
    public class SpheroAsyncPacket : SpheroPacket
    {
       
        public AsyncIdCode IdCode
        {
            get { return (AsyncIdCode)_data[2]; }
        }

        public string AsyncIdCodeDetails
        {
            get { return IdCode.ToString(); }                
        }

        public UInt16 DataLength
        {
            get 
            {
                int msb = _data[3];
                int lsb = _data[4];
                return (UInt16)((msb << 8) | lsb);
            }
        }

        public byte[] Payload
        {
            get 
            { 
                byte[] payload = new byte[DataLength];
                Array.Copy(_data, 5, payload, 0, payload.Length); 
                return payload;
            }
        }

        public SpheroAsyncPacket(byte[] data)
        {
            _data = data;
        }

        public override string ToString()
        {
            const string invalid = "[invalid checksum]->";
            string text = string.Empty;

            if (IdCode == AsyncIdCode.LevelOneDiagnosticResponse)
            {
                string title = "Level 1 Diagnostic Response\n";
                string line = "--------------------------------\n";
                string diagnostic = System.Text.Encoding.Default.GetString(Payload);
                text = title + line + diagnostic + line;
            }
            else if (IdCode == AsyncIdCode.OrbBasicErrorMessageAscii)
            {
                text = System.Text.Encoding.Default.GetString(Payload) + "\n";
            }
            else
            {
                return base.ToString() + string.Format(" - id code is '{0}'", AsyncIdCodeDetails);
            }

            if (!IsValid) text = invalid + text;
            
            return text;
        }

    }
}
