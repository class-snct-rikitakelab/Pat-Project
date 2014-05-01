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
        public SpheroConnector Spconnector = new SpheroConnector();
        public Sphero sp = null;
        public static string lstatusdis;
        public static string lstatuscon;
        public Form1()
        {
            InitializeComponent();


        }
        public void updateLStatus()
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Spconnector.Scan();
            BTconnection.DataSource = Spconnector.DeviceNames;
        }
        public static void whenLConnect()
        {

        }

    }
}
