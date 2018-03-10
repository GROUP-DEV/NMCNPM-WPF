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
    /// Interaction logic for banve.xaml
    /// </summary>
    public partial class banve : UserControl
    {
        //truyen du lieu to window plane
        public delegate void PassData(string s);
        public event PassData DataCB;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();

        public banve()
        {
            InitializeComponent();

            // ham kiem tra
            //checkF v = new checkF();
            //v.Phone = "";
            //v.Email = "";
            //DataContext = v;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaCB();
        }
        int valuecbb = 0;
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataCB?.Invoke("1");// truyền data di cho cac form
        }
        void LoadMaCB()
        {
            cbbMacb.ItemsSource = LT.CHUYENBAY.ToList();
        }
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
            //txtSBDen.Text = sanbayden.TenSB.ToString();
            //txtSBDi.Text = sanbaydi.TenSB.ToString();
            txtngaygio.Text = query.NgayGio.ToString();
            txttgbay.Text = query.ThoiGianBay.ToString();
            //txtgheh1.Text = query.SoLuongGheHang1.ToString();
            //txtgheh2.Text = query.SoLuongGheHang2.ToString();
       
            //var query = (from lb in LT.LICHBAY
            //             from sb in LT.SANBAY
            //             where lb.MaSanBayDen == sb.MaSB || lb.MaSanBayDi == sb.MaSB && lb.MaCB == valuecbb
            //             select new { lb.MaCB, lb.MaSanBayDen, lb.MaSanBayDi, lb.NgayGio, lb.ThoiGianBay, lb.SoLuongGheHang1, lb.SoLuongGheHang2, sb.TenSB }).FirstOrDefault(); /* (m => m.MaCB == valuecbb).FirstOrDefault()*/
        }

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            checkF v = new checkF();
            v.Phone = "";
            v.Email = "";
            DataContext = v;
    
        }

        private void gridSBTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
