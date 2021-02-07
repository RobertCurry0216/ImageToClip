using ImageToClip.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace ImageToClip.ViewModels
{
    public interface IClippingViewModel
    {
        ClipArea ClipArea { get; set; }
        int Height { get; set; }
        int Width { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void MouseMove(object sender, MouseEventArgs e);

        void MouseDown(object sender, MouseButtonEventArgs e);

        void MouseUp(object sender, MouseButtonEventArgs e);
    }
}