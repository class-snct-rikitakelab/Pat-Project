using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpheroNET;

namespace LeapSpv2
{
    public partial class Form1 : Form
    {
        SpheroConnector Spconnector = new SpheroConnector();
        Sphero sp = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Spconnector.Scan();
            BTconnection.DataSource = Spconnector.DeviceNames;
        }

    }
}
