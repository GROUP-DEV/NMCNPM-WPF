using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class trangchu : UserControl
    {
        //SLIDER
        DispatcherTimer timer;
        int ctr = 0;
        //END SLIDER
        mucsic qc = new mucsic();
        public trangchu()
        {
            InitializeComponent();

            //SLIER
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += new EventHandler(timer_Tick);
            //END SLIDER
            timer.IsEnabled = true;
            row.Children.Add(qc);


        }
        // ============================SLIDER=====================
        void timer_Tick(object sender, EventArgs e)
        {
            ctr++;
            if (ctr > 6)
            {
                ctr = 1;
            }
            PlaySlideShow(ctr);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctr = 1;
            PlaySlideShow(ctr);
          
        }
        private void PlaySlideShow(int ctr)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            string filename = ((ctr < 7) ? "../images/plane0" + ctr + ".jpg" : "../images/Plane" + ctr + ".jpg");
            image.UriSource = new Uri(filename, UriKind.Relative);
            image.EndInit();
            myImage.Source = image;
            myImage.Stretch = Stretch.Uniform;
            progressBar1.Value = ctr;
        }
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            ctr = 1;
            PlaySlideShow(ctr);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            ctr--;
            if (ctr < 1)
            {
                ctr = 6;
            }
            PlaySlideShow(ctr);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ctr++;
            if (ctr > 6)
            {
                ctr = 1;
            }
            PlaySlideShow(ctr);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            ctr =6;
            PlaySlideShow(ctr);
        }
        private void chkAutoPlay_Click(object sender, RoutedEventArgs e)
        {
            timer.IsEnabled = chkAutoPlay.IsChecked.Value;
            btnFirst.Visibility = (btnFirst.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
            //btnPrevious.Visibility = (btnPrevious.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
           // btnNext.Visibility = (btnNext.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
            btnLast.Visibility = (btnLast.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
        }
        //===============================END SLIDER=======================
    }
}