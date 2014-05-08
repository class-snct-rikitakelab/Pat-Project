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
using Leap;

namespace LeapSpv2
{
    public partial class Form1 : Form
    {
        public SpheroConnector Spconnector = new SpheroConnector();
        public Sphero sp = null;
        public LeapListener lListener;
        public Controller lctrl;
        public bool lstatuscon = false;
        public Form1()
        {
            InitializeComponent();
            lconn.BackColor = Color.White;
            ldisconn.BackColor = Color.White;
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Spconnector.Scan();
            BTconnection.DataSource = Spconnector.DeviceNames;
        }

        public void whenLConnect()
        {
            lconn.BackColor = Color.LawnGreen;
            ldisconn.BackColor = Color.White;
            lconn.Update();
            ldisconn.Update();
        }

        public void whenLDisconnect()
        {
            ldisconn.BackColor = Color.Red;
            lconn.BackColor = Color.White;
            lconn.Update();
            ldisconn.Update();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            int index = BTconnection.SelectedIndex;
            sp = Spconnector.Connect(index);
            if (lstatuscon)
            {
                Form2 f2 = new Form2();
                this.Hide();
                lListener.SetF2(f2);
                f2.ShowDialog();
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lctrl = new Controller();
            lListener = new LeapListener();
            lctrl.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            lctrl.EnableGesture(Gesture.GestureType.TYPESWIPE);
            lctrl.AddListener(lListener);
            lListener.SetF(this);
        }


    }
}
