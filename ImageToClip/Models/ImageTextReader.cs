using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageToClip.Models
{
    internal class ImageTextReader : DisposableObject
    {
        /// <summary>
        /// OCR engine
        /// </summary>
        private Tesseract _ocr;

        private string dataPath = @"E:\temp\tessdata_best-master\tessdata_best-master\";

        private ClipArea ClipArea;

        /// <summary>
        /// Create a ImageTextReader
        /// </summary>
        /// <param name="dataPath">
        /// The datapath must be the name of the parent directory of tessdata and
        /// must end in / . Any name after the last / will be stripped.
        /// </param>
        public ImageTextReader(ClipArea clipArea)
        {
            ClipArea = clipArea;
            _ocr = new Tesseract(dataPath, "eng", OcrEngineMode.Default);
        }

        private string ReadText()
        {
            Mat mat = new Mat(ClipArea.FilePath, Emgu.CV.CvEnum.ImreadModes.Color);
            Mat gray = new Mat();
            CvInvoke.CvtColor(mat, gray, ColorConversion.Bgr2Gray);
            Pix pix = new Pix(gray);

            _ocr.SetImage(pix);
            _ocr.Recognize();
            var words = _ocr.GetCharacters();

            var str = new StringBuilder();
            foreach (var word in words)
            {
                str.Append(word.Text);
            }

            return str.ToString();
        }

        public void ClipText()
        {
            ClipArea.Capture();
            var text = ReadText();
            Clipboard.SetText(text);
        }

        protected override void DisposeObject()
        {
            _ocr.Dispose();
        }
    }
}