using DoAn.Model;
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

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for chuyenbay.xaml
    /// </summary>
    public partial class chuyenbay : UserControl
    {
        public delegate void PassData(string s);
        public event PassData DataCB;
        // CONNECT DATABSE
        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        public chuyenbay()
        {
            InitializeComponent();
            // txtthemsbtg.Visibility = Visibility.Collapsed;// mặc định nó ẩn

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataCB?.Invoke("1");// truyền data di cho cac form
        }
        void LoadMaCB()
        {
            cbbMacb.ItemsSource = LT.CHUYENBAY.ToList();
        }
        void LoadSBtrunggian(int str)
        {
            gridSBTG.ItemsSource = LT.SANBAYTRUNGGIAN.Where(m => m.MaCB == str).ToList();
        }
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaCB();
            // LoadSBtrunggian();
        }
        int valuecbb = 0;
        private void cbbMacb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            valuecbb = int.Parse(cbbMacb.SelectedValue.ToString());
            var query = LT.LICHBAY.Where(m => m.MaCB == valuecbb).FirstOrDefault();
            var sanbaydi = (from lb in LT.LICHBAY
                            from sb in LT.SANBAY
                            where lb.MaSanBayDi == sb.MaSB && lb.MaCB == valuecbb
                            select new { sb.TenSB }).FirstOrDefault();
            var sanbayden = (from lb in LT.LICHBAY
                             from sb in LT.SANBAY
                             where lb.MaSanBayDen == sb.MaSB && lb.MaCB == valuecbb
                             select new { sb.TenSB }).FirstOrDefault();
            txtSBDen.Text = sanbayden.TenSB.ToString();
            txtSBDi.Text = sanbaydi.TenSB.ToString();
            txtngaygio.Text = query.NgayGio.ToString();
            txttgbay.Text = query.ThoiGianBay.ToString();
            txtgheh1.Text = query.SoLuongGheHang1.ToString();
            txtgheh2.Text = query.SoLuongGheHang2.ToString();
            LoadSBtrunggian(valuecbb);
            //var query = (from lb in LT.LICHBAY
            //             from sb in LT.SANBAY
            //             where lb.MaSanBayDen == sb.MaSB || lb.MaSanBayDi == sb.MaSB && lb.MaCB == valuecbb
            //             select new { lb.MaCB, lb.MaSanBayDen, lb.MaSanBayDi, lb.NgayGio, lb.ThoiGianBay, lb.SoLuongGheHang1, lb.SoLuongGheHang2, sb.TenSB }).FirstOrDefault(); /* (m => m.MaCB == valuecbb).FirstOrDefault()*/
        }

        private void WrapPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            //txttiltle.Visibility = Visibility.Hidden;
            hideMouseEnter();
        }
        private void WrapPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            showMouseLeave();
        }
        void hideMouseEnter()
        {
            //tbcb.Visibility = Visibility.Collapsed;
            tbslghe1.Visibility = Visibility.Collapsed;
            tbslghe2.Visibility = Visibility.Collapsed;
            tbngio.Visibility = Visibility.Collapsed;
            tbsbdi.Visibility = Visibility.Collapsed;
            tbsbden.Visibility = Visibility.Collapsed;
            //  tbtiltle.Text = "THÊM SÂN BAY TRUNG GIAN";
            tbtiltle.Visibility = Visibility.Collapsed;
            tgtgbay.Visibility = Visibility.Collapsed;
            grinfo.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            txtgheh1.Visibility = Visibility.Collapsed;
            txtgheh2.Visibility = Visibility.Collapsed;
            txtngaygio.Visibility = Visibility.Collapsed;
            txtSBDen.Visibility = Visibility.Collapsed;
            txtSBDi.Visibility = Visibility.Collapsed;
            txttgbay.Visibility = Visibility.Collapsed;
            //cbbMacb.Visibility = Visibility.Collapsed;
  
        }
        void showMouseLeave()
        {
            //tbcb.Visibility = Visibility.Visible;
            tbslghe1.Visibility = Visibility.Visible;
            tbslghe2.Visibility = Visibility.Visible;
            tbngio.Visibility = Visibility.Visible;
            tbsbdi.Visibility = Visibility.Visible;
            tbsbden.Visibility = Visibility.Visible;
            // tbtiltle.Text = "NHẬN LỊCH CHUYẾN BAY";
            tbtiltle.Visibility = Visibility.Visible;
            tgtgbay.Visibility = Visibility.Visible;
            grinfo.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
            txtgheh1.Visibility = Visibility.Visible;
            txtgheh2.Visibility = Visibility.Visible;
            txtngaygio.Visibility = Visibility.Visible;
            txtSBDen.Visibility = Visibility.Visible;
            txtSBDi.Visibility = Visibility.Visible;
            txttgbay.Visibility = Visibility.Visible;
            // cbbMacb.Visibility = Visibility.Visible;
   
        }
        // tìm tên 1 element trong datatemplate
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
        string chuoi = "";
        private SANBAYTRUNGGIAN LoopData(string STT)
        {
            var CT = new SANBAYTRUNGGIAN();
            using (var BH = new QLVeMayBayEntities())
            {
                var sanbay = (from h in BH.SANBAY
                              where h.MaSB == chuoi
                              select h);

                foreach (var Temp in sanbay)
                {
                    CT.MaSBTrungGian = Temp.MaSB;
                    CT.TenSB = Temp.TenSB;
                }
            }

            return CT;
        }






       
    }
}
