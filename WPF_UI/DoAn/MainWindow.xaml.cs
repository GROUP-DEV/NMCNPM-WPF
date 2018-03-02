using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using DoAn.Views;
using System.Windows.Threading;
using DoAn.Model;
using DoAn.Controller;

namespace DoAn
{

    public partial class MainWindow : Window
    {

        Model.QLVeMayBayEntities BLT;

        public MainWindow()
        {
            InitializeComponent();
        }
        //Convert byte[] array to BitmapImage
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        //
        string Loged = "";

        //
        trangchu trangchu = new trangchu();
        Setting Settings = new Setting();
        QuangCao qc = new QuangCao();
        //
       

     

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void RunTime_Clock(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            txtIClock.ToolTip = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UserControlView.Children.Clear();
            UserControlView.Children.Add(trangchu);
            //ShowView();
        }
        // button plane
        private void plane_Click(object sender, RoutedEventArgs e)
        {
            UserControlView.Children.Clear();

        }

        //Command 
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserControlView.Children.Clear();
            if (Loged != "")// Lúc người dùng đã đăng nhập hiển thị form xem thông tin
            {
                //HidenView();
                //hidden1.Width = Double.NaN;
              
            }
            else// ngược lại thì hiên thị lại form đăng nhập
            {
               // HidenView();
                //hidden1.Width = Double.NaN;
           
            }
        }
        private void LogOut()
        {
           // DelTableTemp();
            Loged = "";
            txtNameUser.Text = "Khách hàng ?";
            eliUser.ToolTip = "Chưa Đăng Nhập";
            eliUser.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute)));
            plane.Visibility = Visibility.Collapsed;
            planetxt.Visibility = Visibility.Collapsed;
            UserControlView.Children.Clear();
            UserControlView.Children.Add(trangchu);
        }
        private void DangXuat_Click(object sender, RoutedEventArgs e)
        {
            //Fiter View
            Settings.Settings += new Setting.PassData(CaiDat);
            UserControlView.Children.Clear();
            //HidenView();
            UserControlView.Children.Add(Settings);
        }
        //Button click quay luoi
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlView.Children.Count != 0)
            {
                UserControlView.Children.RemoveAt(UserControlView.Children.Count - 1);
                //ShowView();
                //  LoadSP();
            }
        }
        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }
        //HIDDEN MENU
        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }
        //SHOW MENU
        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }
        // CHỨC NĂNG CÀI ĐẶT
        void CaiDat(string i)
        {
            switch (i)
            {
                case "Logout":
                    {
                        LogOut();
                    }
                    break;
                case "Dark":
                    {
                        this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                    }
                    break;
                case "Light":
                    {
                        this.Background = Brushes.White;
                    }
                    break;
                case "Reset":
                    {
                        this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                        FontFamily = new FontFamily("Default");
                        WindowStyle = WindowStyle.SingleBorderWindow;
                    }
                    break;
                case "Full":
                    {
                        WindowStyle = WindowStyle.None;
                    }
                    break;
                case "Windows":
                    {
                        WindowStyle = WindowStyle.SingleBorderWindow;


                    }
                    break;

                default:
                    FontFamily = new FontFamily(i);
                    break;
            }
        }

        private void CaiDat()
        {
            using (var BL = new QLVeMayBayEntities())
            {
                this.FontFamily = new FontFamily((from i in BL.CaiDat
                                                  select i.font).SingleOrDefault());
                if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Dark")
                {
                    this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                }
                else if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Light")
                {
                    this.Background = Brushes.White;
                }

                if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Full")
                {
                    this.WindowStyle = WindowStyle.None;
                }
                else if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Windows")
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlView.Children.Add(trangchu);
            CaiDat();
            BLT = new QLVeMayBayEntities();
            txtDate.ToolTip = DateTime.Now.ToLongDateString() + "\n" + DateTime.Now.DayOfWeek;
            DispatcherTimer RunTime = new DispatcherTimer();
            RunTime.Tick += new EventHandler(RunTime_Clock);
            RunTime.Interval = new TimeSpan(0, 0, 1);
            RunTime.Start();

            //LoadForm Sau 0.1 s
            DispatcherTimer TimeLoad = new DispatcherTimer();
            //TimeLoad.Tick += new EventHandler(TimeLoad_Clock);
            TimeLoad.Interval = new TimeSpan(0, 0, 1);
            TimeLoad.Start();
        }
    }
}
