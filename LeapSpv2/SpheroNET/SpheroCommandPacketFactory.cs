using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{
    public static class SpheroCommandPacketFactory
    {
        public static SpheroCommandPacket EraseOrbBasicStorage(StorageArea area)
        {
            return new SpheroCommandPacket(0x02, 0x60, 0x01, new byte[] { (byte)area });
        }

        public static SpheroCommandPacket AppendOrbBasicFragment(StorageArea area, string fragment)
        {
            List<byte> data = new List<byte>();
            byte[] fragBytes = Encoding.Default.GetBytes(fragment);
            data.Add((byte)area);
            data.AddRange(fragBytes);
            return new SpheroCommandPacket(0x02, 0x61, 0x01, data.ToArray());
        }

        public static SpheroCommandPacket ExecuteOrbBasicProgram(StorageArea area, UInt16 fromLine)
        {
            byte[] data = new byte[3];
            data[0] = (byte)area;
            data[1] = (byte)((fromLine & 0xFF00) >> 8);
            data[2] = (byte)(fromLine & 0x00FF);
            return new SpheroCommandPacket(0x02, 0x62, 0x01, data);
        }

        public static SpheroCommandPacket AbortOrbBasicProgram()
        {
            return new SpheroCommandPacket(0x02, 0x63, 0x01, null);
        }

        public static SpheroCommandPacket Roll(int speed, int heading, int value)
        {
            return new SpheroCommandPacket(0x02, 0x30, 0x01, new byte[] { (byte)speed, (byte)((heading & 0xFF00) >> 8), (byte)(heading & 0x00FF), (byte)value });
        }

        public static SpheroCommandPacket SetRGBLEDOutput(byte r, byte g, byte b)
        {
            bool flag = false;
            return new SpheroCommandPacket(0x02, 0x20, 0x01, new byte[] { r, g, b, (flag ? (byte)0x01 : (byte)0x00) });
        }

        public static SpheroCommandPacket PerformLevelOneDiagnostics()
        {
            return new SpheroCommandPacket(0x00, 0x40, 0x01, null);
        }

        public static SpheroCommandPacket Sleep()
        {
            return new SpheroCommandPacket(0x00, 0x22, 0x01, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        public static SpheroCommandPacket SetHeading(UInt16 heading)
        {
            byte msb = (byte)((heading & 0xFF00) >> 8);
            byte lsb = (byte)(heading & 0x00FF);
            return new SpheroCommandPacket(0x02, 0x01, 0x01, new byte[] { msb, lsb});
        }

    }
}
