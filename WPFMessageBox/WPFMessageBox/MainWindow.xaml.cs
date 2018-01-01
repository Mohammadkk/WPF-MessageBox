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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFMessageBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void txtMessage_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            window.Height = e.NewSize.Height - 100 + 200;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = @"TextBl";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text += @"For 30 minutes on Sunday the biggest debate in football had nothing to do with, well, football.
Unsurprisingly, the incident comes from Buffalo and goes beyond the game, deep into the psychology of the modern athlete. Not much else mattered until there was an answer to this.
Is Bills kicker Steven Hauschka peeing on the field here? Or is he squirting a frozen water bottle?";
        }
    }
}
