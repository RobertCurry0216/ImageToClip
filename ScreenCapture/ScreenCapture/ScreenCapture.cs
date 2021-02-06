using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreenCaptureTest
{
    public class ScreenCapture
    {
        public static Bitmap CaptureScreen(int x1, int y1, int x2, int y2)
        {
            var w = (int)(Math.Abs(x1 - x2) * 1.5);
            var h = (int)(Math.Abs(y1 - y2) * 1.5);
            var x = (int)(Math.Min(x1, x2) * 1.5);
            var y = (int)(Math.Min(y1, y2) * 1.5);
            Size s = new Size();
            s.Width = w;
            s.Height = h;

            Bitmap BMP = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics GFX = Graphics.FromImage(BMP);
            GFX.CopyFromScreen(x, y, 0, 0, s, CopyPixelOperation.SourceCopy);

            return BMP;
        }
    }
}