using DoAn.Controller;
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
    /// Interaction logic for TraCuu.xaml
    /// </summary>
    public partial class TraCuu : UserControl
    {
        //truyen du lieu to window plane
        public delegate void PassData(string s);
        public event PassData DataTC;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        string masbden;
        string masbdi;
        int temp = 0;
        public TraCuu()
        {
            InitializeComponent();

            // ham kiem tra
            //checkF v = new checkF();
            //v.Phone = "";
            //v.Email = "";
            //DataContext = v;
            
        }
        void LoadLichBay()
        {
            try
            {
                var sql = from PHIEUDATVE in LT.PHIEUDATVE
                          orderby PHIEUDATVE.STT
                          select PHIEUDATVE;
                gridBV.ItemsSource = sql.ToList();
            }
            catch (Exception)
            {

                return;
            }
            
        }
      
        void loadSB()
        {
            var sql = LT.SANBAY.ToList();
            cbbMaSBdi.ItemsSource = sql;
            cbbSBden.ItemsSource = sql;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //LoadBV();
          
                loadSB();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataTC?.Invoke("1");// truyền data di cho cac form
        }
        string tenSBdi;
        string tenSBden;

        private void cbbSBden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                masbden = cbbSBden.SelectedValue.ToString();
                var laytenSBden = LT.SANBAY.Where(m => m.MaSB == masbden).SingleOrDefault();
                tenSBden = laytenSBden.TenSB;
                var sql = from cb in LT.CHUYENBAY
                          from sb in LT.LICHBAY
                          where sb.MaCB == cb.MaCB && sb.MaSanBayDen == masbden
                          select new { cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.MaCB, sb.ThoiGianBay };
                gridBV.ItemsSource = sql.ToList();
            }
            catch (Exception)
            {
                return;
            }
          
        }

        private void cbbMaSBdi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                masbdi = cbbMaSBdi.SelectedValue.ToString();
                var laySBdi = LT.SANBAY.Where(m => m.MaSB == masbdi).SingleOrDefault();
                tenSBdi = laySBdi.TenSB;
                var sql = from cb in LT.CHUYENBAY
                          from sb in LT.LICHBAY
                          where sb.MaCB == cb.MaCB && sb.MaSanBayDi == masbdi 
                          select new { cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.MaCB, sb.ThoiGianBay };
                gridBV.ItemsSource = sql.ToList();
               
            }
            catch (Exception)
            {
                return;
            }
        }
        // tiềm kiếm theo sb đi và đến
        private void btntimkiem1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string maCBCBB = tenSBdi + " - " + tenSBden;
                int check = (LT.CHUYENBAY.Where(m => m.TenCB == maCBCBB.ToString())).Count();
                var query = (from cb in LT.CHUYENBAY
                             from sb in LT.LICHBAY
                             where sb.MaCB == cb.MaCB && cb.TenCB == maCBCBB
                             select new { cb.MaCB, cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.ThoiGianBay }).ToList();

                if (check > 0)
                {
                    gridBV.ItemsSource = query;
                    return;
                }
                gridBV.ItemsSource = query;
                MessageBox.Show("Không Có Chuyến Bay " + maCBCBB);
                return;
            }
            catch (Exception)
            {

                return;
            }

        }
        private void btntimkiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (temp == 0)// tra cứu Lịch chuyến bay
                {
                    DateTime minmonth = datepk.SelectedDate.Value;
                    DateTime maxmonth = datepk2.SelectedDate.Value;
                    string maCBCBB = tenSBdi + " - " + tenSBden;
                    int check = (from cb in LT.CHUYENBAY
                                           from sb in LT.LICHBAY
                                           where sb.MaCB == cb.MaCB &&
                                             (DateTime)sb.NgayGio >= minmonth && (DateTime)sb.NgayGio <= maxmonth
                                           select new { cb.MaCB, cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.ThoiGianBay }).Count();

                    var sql = (from cb in LT.CHUYENBAY
                               from sb in LT.LICHBAY
                              where sb.MaCB == cb.MaCB &&
                                (DateTime)sb.NgayGio >= minmonth && (DateTime)sb.NgayGio <= maxmonth
                               select new { cb.MaCB, cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.ThoiGianBay }).ToList();
                    if (check > 0)
                    {
                        gridBV.ItemsSource = sql;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy "+ minmonth +" -> " + maxmonth);
                        return;
                    }
                }
                if (temp == 1)// tra cứu ve
                {
                    DateTime minmonth = datepktracuu.SelectedDate.Value;
                    DateTime maxmonth = datepk2tracuu.SelectedDate.Value;
                    string cmnd = txtcmnd.Text;
                    var check = (from p in LT.PHIEUDATVE// kiểm tra cmnd có tồn tai không
                                 where p.CMND == cmnd
                                 select p).Count();
                    if (check <=0)
                    {
                        MessageBox.Show("Không tìm thấy CMND " + cmnd);
                    }
                    var empty = (from p in LT.PHIEUDATVE
                               where p.CMND == cmnd || p.NgayDat >= minmonth && p.NgayDat <= maxmonth
                               select p).Count();
                    var sql = (from p in LT.PHIEUDATVE
                               where p.CMND == cmnd || p.NgayDat >= minmonth && p.NgayDat <= maxmonth
                               select p).ToList();
                    if (empty <= 0)
                    {
                        MessageBox.Show("Không tìm thấy " + minmonth + " -> " + maxmonth);
                    }
                    gridBanVe.ItemsSource = sql;
                    return;
                    
                    

                }

            }
            catch (Exception)
            {

                return;
            }
         
        }

        private void gridBV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

               
               
            }
            catch (Exception)
            {

                return;
            }
        }

        private void gridBV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == null)
            {
                DataGridRow dgr = sender as DataGridRow;
            }
            else
            {
                return;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btntccb_Click(object sender, RoutedEventArgs e)
        {
            grinfo.Visibility = Visibility.Visible;
            grinfotracuu.Visibility = Visibility.Collapsed;
            gridBV.Visibility = Visibility.Visible;
            gridBanVe.Visibility = Visibility.Collapsed;
            btntccb.Foreground = Brushes.Blue;
            btntcve.Foreground = Brushes.BlueViolet;
            temp = 0;
        }

        private void btntcve_Click(object sender, RoutedEventArgs e)
        {
            grinfo.Visibility = Visibility.Collapsed;
            grinfotracuu.Visibility = Visibility.Visible;
            gridBV.Visibility = Visibility.Collapsed;
            gridBanVe.Visibility = Visibility.Visible;
            btntccb.Foreground = Brushes.BlueViolet;
            btntcve.Foreground = Brushes.Blue;
            temp = 1;
        }
        // ========================END PAGES========================
    }
}
