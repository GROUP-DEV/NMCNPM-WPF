

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
using DoAn.Model;

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
        }

        public delegate void PassData(string i);
        public event PassData Settings;
        private void txtDangXuat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Settings?.Invoke("Logout");
            }
        }
        public string SetLight()
        {
            if (radLight.IsChecked == true)
            {
                Settings?.Invoke("Light");
                return "Light";
            }
            else if (radLight.IsChecked == false)
            {
                Settings?.Invoke("Dark");
                return "Dark";
            }
            return "Dark";
        }
        public string SetFull()
        {
            if (radFull.IsChecked == true)
            {
                Settings?.Invoke("Full");
                return "Full";
            }
            else if (radFull.IsChecked == false)
            {
                Settings?.Invoke("Windows");
                return "Windows";
            }
            return "Windows";
        }
        public string SetFont()
        {
            var cb = cbFonts.SelectedItem as ComboBoxItem;
            var font = cb.Content.ToString();
            Settings.Invoke(font);
            return font;
        }


        public void Saves()
        {
            using (var BH = new Model.QLVeMayBayEntities())
            {
                var sql = BH.CaiDat.Where(m => m.STT == 1).Single(); //as CaiDat;
                sql.FullScreen = SetFull();
                sql.font = SetFont();
                sql.Back = SetLight();
                BH.SaveChanges();//lưu thay doi

            }
        }

        private void txtOKey_Click(object sender, RoutedEventArgs e)
        {
            SetLight();
            SetFont();
            SetFull();
            Saves();

        }
        private void Loads()
        {
            using (var BL = new QLVeMayBayEntities())
            {

                if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Dark")
                {
                    radLight.IsChecked = false;
                }
                else if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Light")
                {
                    radLight.IsChecked = true;
                }

                if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Full")
                {
                    radFull.IsChecked = true;
                }
                else if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Windows")
                {
                    radFull.IsChecked = false;
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Loads();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Settings?.Invoke("Reset");
            using (var BH = new Model.QLVeMayBayEntities())
            {
                var sql = BH.CaiDat.Where(m => m.STT == 1).Single() as CaiDat;
                sql.FullScreen = "Windows";
                sql.font = "Default";
                sql.Back = "Dark";
                BH.SaveChanges();//lưu thay doi

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Exit Application ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }
    }
}

