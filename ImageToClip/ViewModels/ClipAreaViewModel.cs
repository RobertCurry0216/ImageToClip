using ImageToClip.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ImageToClip.ViewModels
{
    public class ClipAreaViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises OnPropertychangedEvent when property changes
        /// </summary>
        /// <param name="name">String representing the property name</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged

        #region Observable Properties

        private int _height;

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        private int _width;

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        private ClipArea _clipArea = new ClipArea();

        public ClipArea ClipArea
        {
            get { return _clipArea; }
            set
            {
                _clipArea = value;
                OnPropertyChanged();
            }
        }

        #endregion Observable Properties

        #region Constructor

        public ClipAreaViewModel()
        {
            Height = 2160;
            Width = 3840;
        }

        #endregion Constructor

        #region Methods

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var mouse = e.GetPosition(sender as Canvas);
                ClipArea c = ClipArea.Clone() as ClipArea;
                c.SetPoint2((int)mouse.X, (int)mouse.Y);
                ClipArea = c;
            }
        }

        internal void MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mouse = e.GetPosition(sender as Canvas);
            var c = new ClipArea();
            c.SetPoint1((int)mouse.X, (int)mouse.Y);
            ClipArea = c;
        }

        internal void MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse up");
            System.Windows.Application.Current.Shutdown();
        }

        #endregion Methods
    }
}