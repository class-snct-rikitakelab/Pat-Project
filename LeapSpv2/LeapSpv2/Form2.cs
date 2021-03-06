﻿using System;
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
    public partial class Form2 : Form
    {
        public void whenSPright()
        {
            rightB.Image = LeapSpv2.Properties.Resources.rBtnP;
            leftB.Image = LeapSpv2.Properties.Resources.leftBtn;
            forwardB.Image = LeapSpv2.Properties.Resources.forwardBtn;
            backwardB.Image = LeapSpv2.Properties.Resources.backwardBtn;
            colorB.Image = LeapSpv2.Properties.Resources.pauseBtn;
            //breakB.BackColor = Color.White;
        }

        public void whenSPleft()
        {
            leftB.Image = LeapSpv2.Properties.Resources.lBtnP;
            rightB.Image = LeapSpv2.Properties.Resources.rightBtn;
            forwardB.Image = LeapSpv2.Properties.Resources.forwardBtn;
            backwardB.Image = LeapSpv2.Properties.Resources.backwardBtn;
            colorB.Image = LeapSpv2.Properties.Resources.pauseBtn;
            //breakB.BackColor = Color.White;
        }

        public void whenSPforward()
        {
            forwardB.Image = LeapSpv2.Properties.Resources.fBtnP;
            rightB.Image = LeapSpv2.Properties.Resources.rightBtn;
            leftB.Image = LeapSpv2.Properties.Resources.leftBtn;
            backwardB.Image = LeapSpv2.Properties.Resources.backwardBtn;
            colorB.Image = LeapSpv2.Properties.Resources.pauseBtn;
            //breakB.BackColor = Color.White;
        }

        public void whenSPbackward()
        {
            backwardB.Image = LeapSpv2.Properties.Resources.bBtnP;
            rightB.Image = LeapSpv2.Properties.Resources.rightBtn;
            leftB.Image = LeapSpv2.Properties.Resources.leftBtn;
            forwardB.Image = LeapSpv2.Properties.Resources.forwardBtn;
            colorB.Image = LeapSpv2.Properties.Resources.pauseBtn;
            //breakB.BackColor = Color.White;
        }

        public void whenSPbreak()
        {
            colorB.Image = LeapSpv2.Properties.Resources.pBtn;
            rightB.Image = LeapSpv2.Properties.Resources.rightBtn;
            leftB.Image = LeapSpv2.Properties.Resources.leftBtn;
            forwardB.Image = LeapSpv2.Properties.Resources.forwardBtn;
            backwardB.Image = LeapSpv2.Properties.Resources.backwardBtn;
        }

        //public void setMoveAngleText(string text)
        //{
        //    moveAngle.Text = text;
        //}

        //public void setCalibateAngleText(string text)
        //{
        //    calibateAngle.Text = text;
        //}
        /*public void whenSPred()
        {
            colorB.Image = LeapSpv2.Properties.Resources.redBtn;
        }*/

        public Form2()
        {
            InitializeComponent();
            //breakB.BackColor = Color.White;
        }
    }
}
