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
    /// Interaction logic for DSChuyenBay.xaml
    /// </summary>
    public partial class DSChuyenBay : UserControl
    {
        //truyen du lieu to window plane
        public delegate void PassData(string s);
        public event PassData DataDSCB;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();

        public DSChuyenBay()
        {
            InitializeComponent();
            // ham kiem tra
            //checkF v = new checkF();
            //v.Phone = "";
            //v.Email = "";
            //DataContext = v;
        }
        void LoadDS()
        {
            try
            {
                //var sql = from cb in LT.CHUYENBAY
                //          from sb in LT.LICHBAY
                //          where sb.MaCB == cb.MaCB
                //          select new { cb.TenCB, sb.NgayGio, sb.SoLuongGheHang1, sb.SoLuongGheHang2, sb.MaCB, sb.ThoiGianBay };
                //gridDSCB.ItemsSource = sql.ToList();
                var sql = (from lb in LT.LICHBAY
                           from ds in LT.DANHSACHCHUYENBAY
                           from cb in LT.CHUYENBAY
                           where lb.MaCB == cb.MaCB && cb.MaCB == ds.MaCB
                           select new
                           {
                               cb.TenCB,
                               lb.MaCB,
                               lb.NgayGio,
                               lb.ThoiGianBay,
                               ds.TongSoGhe,
                               ds.SoLuongGheDat,
                               ds.SoLuongGheTrong
                           });
                gridDSCB.ItemsSource = sql.ToList();
            }
            catch (Exception)
            {

                return;
            }
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDS();
            //LoadBV();


        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataDSCB?.Invoke("1");// truyền data di cho cac form
        }

        // ========================END PAGES========================
    }
}
