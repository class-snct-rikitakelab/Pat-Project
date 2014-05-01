using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpheroNET;
using Leap;

namespace LeapSpv2
{
    class LeapListener : Listener
    {
        Form1 f = new Form1();
        private long currentTime, previousTime, timeChange;
        const int FramePause = 50000;
        public override void OnConnect(Controller arg0)
        {
            Form1.lstatuscon
        }
        public override void OnDisconnect(Controller arg0)
        {
            Form1.lstatusdis
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
                            }
                        }
                    }
                    previousTime = currentTime;
                }
            }
        }
    }
}
