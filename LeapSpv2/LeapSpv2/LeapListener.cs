using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override void OnFrame(Controller ctrl)
        {
            Frame frame = ctrl.Frame();
            this.currentTime = frame.Timestamp;
            this.timeChange = currentTime - previousTime;
            int i;
            if (frame.Hands.Count == 1)
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
                                        f.sp.Roll(10, 90, 1);
                                    }
                                    else
                                    {
                                        //left
                                        f.sp.Roll(10, 270, 1);
                                    }
                                }
                                else
                                {
                                    if (swipeGesture.Direction.y > 0)
                                    {
                                        //forward
                                        f.sp.Roll(10, 0, 1);
                                    }
                                    else
                                    {
                                        //backward
                                        f.sp.Roll(10, 180, 1);
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
                                f.sp.SetRGBLEDOutput(255, 0, 0);
                            }
                        }
                    }
                    previousTime = currentTime;
                }
                else if (Rhand.Fingers.Count < 1)
                {
                    if (timeChange > FramePause)
                    {
                        /*GestureList gestures = frame.Gestures();
                        for (i = 0; i < gestures.Count; i++)
                        {
                            Gesture gesture = gestures[0];
                            if (gesture.Type == Gesture.GestureType.TYPECIRCLE)
                            {
                                //Stop
                            }
                        }*/
                    }
                    previousTime = currentTime;
                }
            }
        }
    }
}
