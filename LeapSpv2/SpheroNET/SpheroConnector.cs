using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net.Sockets;
using System.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using System.Threading;

namespace SpheroNET
{
    public class SpheroConnector
    {

        List<BluetoothDeviceInfo> _devices;
        List<string> _deviceNames;
        BluetoothClient _client;

        public List<string> DeviceNames
        {
            get { return _deviceNames; }
            set { _deviceNames = value; }
        }

        public SpheroConnector()
        {
            Initialize();
        }

        public Sphero Connect(int index)
        {
            BluetoothDeviceInfo deviceInfo = _devices.Count > index ? _devices[index] : null;
            if (deviceInfo != null)
            {
                return new Sphero(Connect(deviceInfo, 5));
            }
            else
            {
                throw new Exception(string.Format("There is no device at index '{0}'.", index));
            }
        }

        public Sphero Connect(string deviceName)
        {
            BluetoothDeviceInfo deviceInfo = _devices.Find(p => p.DeviceName == deviceName);
            if (deviceInfo != null)
            {
                return new Sphero(Connect(deviceInfo, 5));
            }
            else
            {
                throw new Exception(string.Format("There is no device by the name '{0}'.", deviceName));
            }
        }

        public void Close()
        {
            _client.Close();
            _client.Dispose();
            _deviceNames.Clear();
            _devices.Clear();
        }

        public void Scan()
        {
            Initialize();
            DiscoverDevices();
        }

        private void Initialize()
        {
            _devices = new List<BluetoothDeviceInfo>();
            _deviceNames = new List<string>();
            _client = new BluetoothClient();
            _client.InquiryLength = TimeSpan.FromSeconds(2);
        }

        private NetworkStream Connect(BluetoothDeviceInfo device, int retries)
        {

            BluetoothAddress addr = device.DeviceAddress;
            Guid serviceClass = BluetoothService.SerialPort;
            var ep = new BluetoothEndPoint(addr, serviceClass);
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    _client.Connect(ep);
                    break;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(300);
                    if (i == (retries - 1))
                        throw new Exception(
                            string.Format(
                            "Could not connect after {0} retries.", retries), ex);
                }
            }
            NetworkStream stream = _client.GetStream();
            stream.ReadTimeout = 100;
            return stream;
        }

        private void DiscoverDevices()
        {
            _devices.AddRange(_client.DiscoverDevices());
            _deviceNames = GetDeviceNames();
        }

        private List<string> GetDeviceNames()
        {
            List<string> deviceNames = new List<string>();
            if (_devices != null && _devices.Count > 0)
            {
                for (int i = 0; i < _devices.Count; i++)
                {
                    var peer = _devices[i];
                    deviceNames.Add(peer.DeviceName);
                }
            }
            return deviceNames;
        }

    }
}
