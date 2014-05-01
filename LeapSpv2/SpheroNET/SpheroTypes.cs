using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpheroNET
{

    public static class SpheroTypeHelper
    { 
        public static ResponseCode ByteToResponseCode(byte value)
        {
            return (ResponseCode)value;
        }

        public static string GetResponseCodeDetails(byte responseCode)
        {
            return GetResponseCodeDetails(ByteToResponseCode(responseCode));
        }

        public static string GetResponseCodeDetails(ResponseCode responseCode)
        {
            switch (responseCode)
            {
                case ResponseCode.RSP_CODE_OK: return "Command succeeded";
                case ResponseCode.RSP_CODE_EGEN: return "General, non-specific error";
                case ResponseCode.RSP_CODE_EFRAG: return "Received command fragment";
                case ResponseCode.RSP_CODE_EBAD_CMD: return "Unknown command ID";
                case ResponseCode.RSP_CODE_EUNSUPP: return "Command currently unsupported";
                case ResponseCode.RSP_CODE_EBAD_MSG: return "Bad message format";
                case ResponseCode.RSP_CODE_EPARAM: return "Parameter value(s) invalid";
                case ResponseCode.RSP_CODE_EEXEC: return "Failed to execute command";
                case ResponseCode.RSP_CODE_EBAD_DID: return "Unknown Device ID";
                case ResponseCode.RSP_CODE_POWER_NOGOOD: return "Voltage too low for reflash operation";
                case ResponseCode.RSP_CODE_PAGE_ILLEGAL: return "Illegal page number provided";
                case ResponseCode.RSP_CODE_FLASH_FAIL: return "Page did not reprogram correctly";
                case ResponseCode.RSP_CODE_MA_CORRUPT: return "Main Application corrupt";
                case ResponseCode.RSP_CODE_MSG_TIMEOUT: return "Msg state machine timed out";
                case ResponseCode.None: return "There was no response or the response was invalid.";
                default: return string.Empty;
            }
        }

    }

    public enum StorageArea
    {
        Temporary = 0,
        Persistent = 1
    }

    public enum ResponseCode
    {
        RSP_CODE_OK = 0x00,              // Command succeeded
        RSP_CODE_EGEN = 0x01,            // General, non-specific error
        RSP_CODE_ECHKSUM = 0x02,         // Received checksum failure
        RSP_CODE_EFRAG = 0x03,           // Received command fragment
        RSP_CODE_EBAD_CMD = 0x04,        // Unknown command ID
        RSP_CODE_EUNSUPP = 0x05,         // Command currently unsupported
        RSP_CODE_EBAD_MSG = 0x06,        // Bad message format
        RSP_CODE_EPARAM = 0x07,          // Parameter value(s) invalid
        RSP_CODE_EEXEC = 0x08,           // Failed to execute command
        RSP_CODE_EBAD_DID = 0x09,        // Unknown Device ID
        RSP_CODE_POWER_NOGOOD = 0x31,    // Voltage too low for reflash operation
        RSP_CODE_PAGE_ILLEGAL = 0x32,    // Illegal page number provided
        RSP_CODE_FLASH_FAIL = 0x33,      // Page did not reprogram correctly
        RSP_CODE_MA_CORRUPT = 0x34,      // Main Application corrupt
        RSP_CODE_MSG_TIMEOUT = 0x35,     // Msg state machine timed out
        None = 0xFF
    }

    public enum AsyncIdCode
    {
        PowerNotifications = 0x01,
        LevelOneDiagnosticResponse = 0x02,
        SensorDataStreaming = 0x03,
        ConfigBlockContents = 0x04,
        PreSleepWarning = 0x05,
        MacroMarkers = 0x06,
        CollisionDetected = 0x07,
        OrbBasicPrintMessage = 0x08,
        OrbBasicErrorMessageAscii = 0x09,
        OrbBasicErrorMessageBinary = 0x0A
    }

}
