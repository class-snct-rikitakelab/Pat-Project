using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SpheroNET;
using Leap;

namespace LeapSpv2
{
    public class LeapListener : Listener
    {
        private long currentTime, previousTime, timeChange;
        const int FramePause = 50000;
        private Form1 f;
        private Form2 f2;
        private double baseX;
        private double baseZ;
        private int angle = 0;
        private int baseReset = 20;
        private int baseReset2 = 0;
        private int mode = 0;
        private bool calibate = false;
        public void SetF(Form1 ff)
        {
            f = ff;
        }
        public void SetF2(Form2 ff)
        {
            f2 = ff;
        }
        public override void OnConnect(Controller arg0)
        {
          //  Form1.lstatuscon
            f.whenLConnect();
            f.lstatuscon = true;
        }
        public override void OnDisconnect(Controller arg0)
        {
           // Form1.lstatusdis
            f.whenLDisconnect();
            f.lstatuscon = false;
        }
        public double filter(double m)
        {
            if (m > 2)
                return m - 2;
            else if (m < -2)
                return m + 2;
            return 0;
        }
        public override void OnFrame(Controller ctrl)
        {
            Frame frame = ctrl.Frame();
            Hand hand = frame.Hands[0];
            int n = frame.Pointables.Count;
            if (!calibate && f.sp != null)
            {
                f.sp.SetRGBLEDOutput(255, 255, 255);
                f.sp.SetBackLEDOutput(255);
                if (frame.Hands.Count > 0 && n <= 2) {
                    angle = (angle + 2) % 360;
                    f.sp.Roll(0,angle, 1);
                    //f2.setCalibateAngleText("Degree : " + (int)angle);

                }
                else if (frame.Hands.Count > 0 && n >= 5)
                {
                    f.sp.SetBackLEDOutput(0);
                    calibate = true;
                }
            }
            if (frame.Hands.Count > 0 && f.sp != null && calibate)
            {
                if (mode == 0 && n > 3)
                {
                    baseReset2 = 0;
                }
                else if (mode == 0 && n <= 2)
                {
                    if (baseReset2++ > 20)
                        mode = 1;
                    f.sp.SetRGBLEDOutput(255, 0, 0);
                    f2.whenSPbreak();
                }
                else if (mode == 1 && n >= 5)
                {
                    baseReset = 0;
                    baseX = hand.PalmPosition.x;
                    baseZ = hand.PalmPosition.z;
                    mode = 2;
                    f.sp.SetRGBLEDOutput(0, 255, 0);
                }
                else if (mode == 2 && n <= 2)
                {
                    if (baseReset++ > 20 || n == 0)
                    {
                        mode = 0;
                        baseReset2 = 0;
                        f.sp.Roll(0, 0, 1);
                        f.sp.SetRGBLEDOutput(0, 0, 255);
                    }
                }
                if (mode == 2)
                {
                    double x = filter(hand.PalmPosition.x - baseX);
                    double z = -filter(hand.PalmPosition.z - baseZ);
                    double speed = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
                    double deg = Math.Atan2(x, z) / Math.PI * 180;
                    deg = (deg + angle + 360) % 360;
                    deg = deg - 90;
                    //f2.setMoveAngleText("Degree : " + deg.ToString());
                    f.sp.Roll((int)speed, (int)deg, 1);
                    //change color
                    int rNum, gNum, bNum;
                    Random r = new Random();
                    rNum = r.Next(0, 255);
                    gNum = r.Next(0, 255);
                    bNum = r.Next(0, 255);
                    f.sp.SetRGBLEDOutput((byte)rNum, (byte)gNum, (byte)bNum);
                    if (deg > 315 || deg < 45)
                    {
                        // forward
                        f2.whenSPforward();
                    }
                    if (deg >= 45 || deg < 135)
                    {
                        // right
                        f2.whenSPright();
                    }
                    if (deg >= 135 || deg < 225)
                    {
                        // backward
                        f2.whenSPbackward();
                    }
                    if (deg >= 225 || deg < 315)
                    {
                        // left
                        f2.whenSPleft();
                    }

                }
            }
            else
            {
                if (baseReset++ > 20)
                {
                    if (mode == 2)
                    {
                        mode = 0;
                        baseReset2 = 0;
                        f.sp.Roll(0, 0, 1);
                    }
                }
            }

            /*this.currentTime = frame.Timestamp;
            this.timeChange = currentTime - previousTime;
            int i;
            if (frame.Hands.Count == 1 && f.sp != null)
            {
                Hand Rhand = frame.Hands.Rightmost;
                if (Rhand.Fingers.Count > 1)
                {
                    if (timeChange > FramePause)
                    {
                        GestureList gestures = frame.Gestures();
                        for (i = 0; i < gestures.Count; i++)
                        {
                            Gesture gesture = gestures[0];
                            if (gesture.Type == Gesture.GestureType.TYPESWIPE)
                            {
                                SwipeGesture swipeGesture = new SwipeGesture(gesture);
                                var isHorizontal = System.Math.Abs(swipeGesture.Direction.x) > System.Math.Abs(swipeGesture.Direction.y);
                                if (isHorizontal)
                                {
                                    if (swipeGesture.Direction.x > 0)
                                    {
                                        //right
                                        //f.sp.SendPacket(new SpheroCommandPacket (0x02, 0x30, 0x01, new byte[] { (byte)10, (byte)((90 & 0xFF00) >> 8), (byte)(90 & 0x00FF), (byte)1 }));
                                        f.sp.Roll(100, 90, 1);
                                        Thread.Sleep(2000);
                                        f.sp.Roll(0, 90, 1);
                                        f2.whenSPright();
                                    }
                                    else
                                    {
                                        //left
                                        f.sp.Roll(100, 270, 1);
                                        Thread.Sleep(2000);
                                        f.sp.Roll(0, 270, 1);                                        
                                        f2.whenSPleft();
                                    }
                                }
                                else
                                {
                                    if (swipeGesture.Direction.y > 0)
                                    {
                                        //forward
                                        f.sp.Roll(100, 0, 1);
                                        Thread.Sleep(2000);
                                        f.sp.Roll(0, 0, 1);                                       
                                        f2.whenSPforward();
                                    }
                                    else
                                    {
                                        //backward
                                        f.sp.Roll(100, 180, 1);
                                        Thread.Sleep(2000);
                                        f.sp.Roll(0, 180, 1); 
                                        f2.whenSPbackward();
                                    }
                                }
                                break;
                            }
                        }
                        previousTime = currentTime;
                    }
                }
                else if (Rhand.Fingers.Count == 1)
                {
                    if (timeChange > FramePause)
                    {
                        GestureList gestures = frame.Gestures();
                        for (i = 0; i < gestures.Count; i++)
                        {
                            Gesture gesture = gestures[0];
                            if (gesture.Type == Gesture.GestureType.TYPECIRCLE)
                            {
                                //change color
                                int rNum,gNum,bNum;
                                Random r = new Random();
                                rNum = r.Next(0, 255);
                                gNum = r.Next(0, 255);
                                bNum = r.Next(0, 255);
                                f.sp.SetRGBLEDOutput((byte)rNum, (byte)gNum, (byte)bNum);
                                f2.whenSPred();
                            }
                            else if (gesture.Type == Gesture.GestureType.TYPESCREENTAP)
                            {
                                f.sp.Sleep();
                            }
                        }
                    }
                    previousTime = currentTime;
                }
                else if (Rhand.Fingers.Count < 1)
                {
                    f.sp.Roll(0, 0, 1);
                    f2.whenSPbreak();
                    /*if (timeChange > FramePause)
                    {
                        f.sp.Roll(0, 0, 1);
                        f2.whenSPbreak();
                        /*GestureList gestures = frame.Gestures();
                        for (i = 0; i < gestures.Count; i++)
                        {
                            Gesture gesture = gestures[0];
                            if (gesture.Type == Gesture.GestureType.TYPECIRCLE)
                            {
                                //Stop
                            }
                        }
                    }
                    previousTime = currentTime;
                }
            }*/
        }
    }
}
