using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public Bitmap Bmp { get; private set; }

        public string FilePath { get; private set; }

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
            Bmp = ScreenCapture.ScreenCapture.CaptureScreen(Left, Top, Right, Bottom, scale: 1.5);
            FilePath = CreateTmpFile();
            Bmp.Save(FilePath);
        }

        private static string CreateTmpFile()
        {
            string fileName = string.Empty;

            try
            {
                // Get the full name of the newly created Temporary file.
                // Note that the GetTempFileName() method actually creates
                // a 0-byte file and returns the name of the created file.
                fileName = Path.GetTempFileName();

                // Craete a FileInfo object to set the file's attributes
                FileInfo fileInfo = new FileInfo(fileName);

                // Set the Attribute property of this file to Temporary.
                // Although this is not completely necessary, the .NET Framework is able
                // to optimize the use of Temporary files by keeping them cached in memory.
                fileInfo.Attributes = FileAttributes.Temporary;

                Console.WriteLine("TEMP file created at: " + fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create TEMP file or set its attributes: " + ex.Message);
            }

            return fileName;
        }

        #endregion Methods
    }
}