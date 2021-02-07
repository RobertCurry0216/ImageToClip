using ImageToClip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageToClip.Views
{
    /// <summary>
    /// Interaction logic for ClipAreaView.xaml
    /// </summary>
    public partial class ClipAreaView : Window
    {
        public ClipAreaView()
        {
            InitializeComponent();
        }

        private void ClipArea_MouseMove(object sender, MouseEventArgs e)
        {
            ((ClipAreaViewModel)DataContext).MouseMove(sender, e);
        }

        private void ClipArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClipAreaViewModel)DataContext).MouseDown(sender, e);
        }

        private void ClipArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            ((ClipAreaViewModel)DataContext).MouseUp(sender, e);
        }
    }
}