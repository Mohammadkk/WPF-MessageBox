using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WPFMessageBox
{
    class SMBox
    {
        static MainWindow window1;
        static SMBDirection dir = SMBDirection.LeftToRight;
        static SMBResult res;
        static string iconaddress = null;
        static string FontName = null;
        static double fontSize;
        static Brush BG;


        public enum SMBButton
        {
            OK,
            OkCancel,
            YesNo,
            YesNoCancel
        }

        public enum SMBResult
        {
            Ok,
            Yes,
            No,
            Cancel,
            None
        }

        public enum SMBFont
        {
            Tahoma,
            Arshia
        }

        public enum SMBIcon
        {
            gold,
            blue
        }

        public enum SMBDirection
        {
            RightToLeft,
            LeftToRight
        }

        public enum SMBBG
        {
            Red,
            Blue
        }

        static void Icomponent()
        {
            window1 = new MainWindow();
            switch (dir)
            {
                case SMBDirection.LeftToRight:
                    window1.FlowDirection = FlowDirection.LeftToRight;
                    break;
                case SMBDirection.RightToLeft:
                    window1.FlowDirection = FlowDirection.RightToLeft;
                    break;
                default:
                    window1.FlowDirection = FlowDirection.LeftToRight;
                    break;
            }
            if (iconaddress != null)
            {
                window1.image.Source = new BitmapImage(new Uri(iconaddress, UriKind.Relative));
            }

            if (FontName != null)
            {
                window1.txtMessage.FontFamily = new System.Windows.Media.FontFamily(FontName);
                window1.txtMessage.FontSize = fontSize;
            }

            if (BG != null)
            {
                window1.rect.Fill = BG;
            }

            window1.btn1.Click += new RoutedEventHandler(btn_click);
            window1.btn2.Click += new RoutedEventHandler(btn_click);
            window1.btn3.Click += new RoutedEventHandler(btn_click);
            window1.btnClose.MouseLeftButtonUp += new MouseButtonEventHandler(btnClose_MouseLeftButtonUp);
            window1.btn1.KeyDown += new KeyEventHandler(btn_keydown);
            window1.btn2.KeyDown += new KeyEventHandler(btn_keydown);
            window1.btn3.KeyDown += new KeyEventHandler(btn_keydown);

            window1.btn1.Focus();
        }

        static void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            res = SMBResult.None;
            window1.Close();

        }

        static void btn_click(object sender, RoutedEventArgs e)
        {
            Button btns = sender as Button;
            if (window1.FlowDirection == FlowDirection.RightToLeft)
            {
                switch (btns.Content.ToString())
                {
                    case "تایید":
                        res = SMBResult.Ok;
                        break;
                    case "بله":
                        res = SMBResult.Yes;
                        break;
                    case "خیر":
                        res = SMBResult.No;
                        break;
                    case "لغو":
                        res = SMBResult.Cancel;
                        break;
                }
            }
            else
            {
                res = (SMBResult)Enum.Parse(typeof(SMBResult), btns.Content.ToString());
            }
            window1.Close();
        }

        static void btn_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_click(sender, null);
            }

        }

        static void Ibuttons(SMBButton btns)
        {
            window1.btn1.Visibility = window1.btn2.Visibility = window1.btn3.Visibility = Visibility.Visible;

            if (dir == SMBDirection.LeftToRight)
            {
                switch (btns)
                {
                    case SMBButton.OK:
                        window1.btn1.Content = "Ok";
                        window1.btn2.Visibility = Visibility.Hidden;
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.OkCancel:
                        window1.btn1.Content = "Ok";
                        window1.btn2.Content = "Cancel";
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.YesNo:
                        window1.btn1.Content = "Yes";
                        window1.btn2.Content = "No";
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.YesNoCancel:
                        window1.btn1.Content = "Yes";
                        window1.btn2.Content = "No";
                        window1.btn3.Content = "Cancel";
                        break;
                }
            }
            else
            {
                switch (btns)
                {
                    case SMBButton.OK:
                        window1.btn1.Content = "تایید";
                        window1.btn2.Visibility = Visibility.Hidden;
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.OkCancel:
                        window1.btn1.Content = "تایید";
                        window1.btn2.Content = "لغو";
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.YesNo:
                        window1.btn1.Content = "بله";
                        window1.btn2.Content = "خیر";
                        window1.btn3.Visibility = Visibility.Hidden;
                        break;
                    case SMBButton.YesNoCancel:
                        window1.btn1.Content = "بله";
                        window1.btn2.Content = "خیر";
                        window1.btn3.Content = "لغو";
                        break;
                }
            }
        }

        static void IIcon(SMBIcon icon)
        {
            switch (icon)
            {
                case SMBIcon.gold:
                    iconaddress = "img/Exclamation.png";
                    break;
                case SMBIcon.blue:
                    iconaddress = "img/Information.png";
                    break;
                default:
                    iconaddress = null;
                    break;
            }
        }

        static void IFont(SMBFont font, double fsize)
        {
            switch (font)
            {
                case SMBFont.Tahoma:
                    FontName = "Tahoma";
                    break;
                case SMBFont.Arshia:
                    FontName = "2 Arshia";
                    break;
                default:
                    FontName = null;
                    break;
            }
        }

        static void IBrush(SMBBG backG)
        {
            LinearGradientBrush LGB;
            switch (backG)
            {
                case SMBBG.Red:
                    LGB = new LinearGradientBrush();
                    LGB.StartPoint = new Point(0.5, 0);
                    LGB.EndPoint = new Point(0.5, 1);
                    LGB.GradientStops.Add(new GradientStop(Color.FromRgb(255, 161, 161), 0));
                    LGB.GradientStops.Add(new GradientStop(Color.FromRgb(255, 113, 113), 1));
                    BG = LGB;
                    break;
                case SMBBG.Blue:
                    LGB = new LinearGradientBrush();
                    LGB.StartPoint = new Point(0.5, 0);
                    LGB.EndPoint = new Point(0.5, 1);
                    LGB.GradientStops.Add(new GradientStop(Color.FromRgb(161, 235, 255), 0));
                    LGB.GradientStops.Add(new GradientStop(Color.FromRgb(113, 215, 255), 1));
                    BG = LGB;
                    break; ;
                default:
                    BG = null;
                    break;
            }
        }

        public static SMBResult Show(string Message)
        {
            dir = SMBDirection.LeftToRight;
            Icomponent();
            window1.txtMessage.Text = Message;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title)
        {
            dir = SMBDirection.LeftToRight;
            Icomponent();
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title, SMBButton buttons)
        {
            dir = SMBDirection.LeftToRight;
            Icomponent();
            Ibuttons(buttons);
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title, SMBButton buttons, SMBDirection Direction)
        {
            dir = Direction;
            Icomponent();
            Ibuttons(buttons);
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title, SMBButton buttons, SMBDirection Direction, SMBIcon icon)
        {
            dir = Direction;
            IIcon(icon);
            Icomponent();
            Ibuttons(buttons);
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title, SMBButton buttons, SMBDirection Direction, SMBIcon icon, SMBFont FontFamilly, double FontSize)
        {
            dir = Direction;
            IIcon(icon);
            IFont(FontFamilly, FontSize);
            Icomponent();
            Ibuttons(buttons);
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.ShowDialog();
            return res;
        }

        public static SMBResult Show(string Message, string title, SMBButton buttons, SMBDirection Direction, SMBIcon icon, SMBFont FontFamilly, double FontSize, SMBBG Background, double Opacity)
        {
            dir = Direction;
            IIcon(icon);
            IFont(FontFamilly, FontSize);
            IBrush(Background);
            Icomponent();
            Ibuttons(buttons);
            window1.txtMessage.Text = Message;
            window1.txtTitle.Text = title;
            window1.rect.Opacity = Opacity;
            System.Media.SystemSounds.Beep.Play();
            window1.ShowDialog();
            return res;
        }
    }
}
