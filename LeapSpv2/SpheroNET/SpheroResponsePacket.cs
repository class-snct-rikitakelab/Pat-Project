using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{
    public class SpheroResponsePacket: SpheroPacket
    {

        public ResponseCode ResponseCode
        {
            get { return _data.Length > 2 ? SpheroTypeHelper.ByteToResponseCode(_data[2]) : ResponseCode.None; }
        }

        public string ResponseCodeDetails
        {
            get { return SpheroTypeHelper.GetResponseCodeDetails(ResponseCode); }
        }

        public byte SequenceNumber
        {
            get { return _data[3]; }
        }

        public byte DataLength
        {
            get { return _data[4]; }
        }

        public SpheroResponsePacket(byte[] data)
        {
            _data = data;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + ResponseCodeDetails;
        }

    }
}
