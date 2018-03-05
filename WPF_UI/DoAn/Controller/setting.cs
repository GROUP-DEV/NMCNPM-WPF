using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DoAn.Controller
{
    class setting:MainWindow
    {
        MainWindow m = new MainWindow();
        // CHỨC NĂNG CÀI ĐẶT
        public void LogOut()
        {
            // DelTableTemp();
            //Loged = "";
            txtNameUser.Text = "Khách hàng ?";
            eliUser.ToolTip = "Chưa Đăng Nhập";
            eliUser.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute)));

        }
        public void CaiDat(string i)
        {
            switch (i)
            {
                case "Logout":
                    {
                        //m.LogOut();
                    }
                    break;
                case "Dark":
                    {
                        m.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                    }
                    break;
                case "Light":
                    {
                        m.Background = Brushes.White;
                    }
                    break;
                case "Reset":
                    {
                        m.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                        m.FontFamily = new FontFamily("Default");
                        m.WindowStyle = WindowStyle.SingleBorderWindow;
                    }
                    break;
                case "Full":
                    {
                        m.WindowStyle = WindowStyle.None;
                    }
                    break;
                case "Windows":
                    {
                        m.WindowStyle = WindowStyle.SingleBorderWindow;


                    }
                    break;

                default:
                    m.FontFamily = new FontFamily(i);
                    break;
            }
        }

        public void CaiDat()
        {
            using (var BL = new QLVeMayBayEntities())
            {
                m.FontFamily = new FontFamily((from i in BL.CaiDat
                                                  select i.font).SingleOrDefault());
                if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Dark")
                {
                    m.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                }
                else if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Light")
                {
                    m.Background = Brushes.WhiteSmoke;
                }

                if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Full")
                {
                    m.WindowStyle = WindowStyle.None;
                }
                else if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Windows")
                {
                    m.WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }
    }
}
