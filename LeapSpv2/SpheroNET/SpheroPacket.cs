using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{
    public abstract class SpheroPacket
    {
        protected byte[] _data = null;

        public bool IsValid
        {
            get
            {
                return CalculatedChecksum.HasValue && Checksum == CalculatedChecksum.Value;
            }
        }

        public byte[] Data
        {
            get
            {
                return _data;
            }
        }

        public byte SOP1
        { 
            get 
            { 
                return _data[0]; 
            } 
        }

        public byte SOP2
        { 
            get 
            { 
                return _data[1]; 
            } 
        }

        public byte Checksum
        {
            get { return _data[_data.Length - 1]; }
            set { _data[_data.Length - 1] = value; }
        }

        public byte? CalculatedChecksum
        { 
            get 
            { 
                return GetChecksum(); 
            } 
        }

        protected SpheroPacket()
        {
            _data = new Byte[] { 0xFF, 0xFF };
        }

        public void UpdateChecksum()
        {
            byte? checksum = GetChecksum();
            if (checksum.HasValue)
            {
                _data[_data.Length - 1] = checksum.Value;
            }
        }

        public byte? GetChecksum()
        {
            if (_data == null || _data.Length < 4) return null;
            uint sum = 0;
            for (int i = 2; i < _data.Length - 1; i++)
            {
                sum += _data[i];
            }
            return ((Byte)~(sum % 256));
        }

        public override string ToString()
        {
            const string invalid = "[invalid checksum!]->";
            byte[] data = Data;
            var sb = new StringBuilder(data.Length * 3);
            if (!IsValid) sb.Append(invalid);
            foreach (var b in data)
            {
                sb.Append(string.Format("{0:X02}", b));
            }
            return sb.ToString();
        }

    }
}
