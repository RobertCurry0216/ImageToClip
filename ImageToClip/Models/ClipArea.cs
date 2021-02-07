﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToClip.Models
{
    public class ClipArea : ICloneable
    {
        #region properties

        private Point P1;
        private Point P2;

        public int Top => Math.Min(P1.Y, P2.Y);
        public int Left => Math.Min(P1.X, P2.X);
        public int Right => Math.Max(P1.X, P2.X);
        public int Bottom => Math.Max(P1.Y, P2.Y);
        public int Width => Math.Abs(P1.X - P2.X);
        public int Height => Math.Abs(P1.Y - P2.Y);

        #endregion properties

        #region constructor

        public ClipArea()
        {
            P1 = new Point(0, 0);
            P2 = new Point(0, 0);
        }

        #endregion constructor

        #region Methods

        public void SetPoint1(int x, int y)
        {
            P1 = new Point(x, y);
        }

        public void SetPoint2(int x, int y)
        {
            P2 = new Point(x, y);
        }

        public object Clone()
        {
            var c = new ClipArea();
            c.P1 = P1;
            c.P2 = P2;
            return c;
        }

        public void Capture()
        {
            var bmp = ScreenCapture.ScreenCapture.CaptureScreen(Left, Top, Right, Bottom, scale: 1.5);
            bmp.Save(@"E:\temp\test.png");
        }

        #endregion Methods
    }
}