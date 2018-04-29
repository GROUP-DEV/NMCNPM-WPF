using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
    /// Interaction logic for BaoCao.xaml
    /// </summary>
    public partial class BaoCao : UserControl
    {
        //truyen du lieu to window plane
        public delegate void PassData(string s);
        public event PassData DataDSBC;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();

        public BaoCao()
        {
            InitializeComponent();
            // ham kiem tra
            //checkF v = new checkF();
            //v.Phone = "";
            //v.Email = "";
            //DataContext = v;
        }
        void baocaonam(int nam)
        {
            try
            {
                // =========sql lấy tổng doanh thu, thang, sochuyen bay==========
                var sql = from tab in (// 
                                            (from p in LT.PHIEUDATVE
                                             where
                                               SqlFunctions.DatePart("year", p.NgayDat) == nam
                                             group new { p, p.CHUYENBAY } by new
                                             {
                                                 Column1 = (int?)SqlFunctions.DatePart("month", p.NgayDat)// group by theo tháng thôi
                                             } into g
                                             select new
                                             {
                                                 Thang = g.Key.Column1,
                                                 DoanhThu = (int?)g.Sum(p => p.p.DonGia),
                                                 SoChuyenBay = g.Count(p => p.p.MaCB != null)
                                             }))

                    // =========lấy doanh thu của tháng đàu================
                    from mth in (from pr in
                                (from pr in LT.PHIEUDATVE
                                where
                                    SqlFunctions.DatePart("year", pr.NgayDat) == nam &&
                                    SqlFunctions.DatePart("month", pr.NgayDat) ==
                                                (from ptem in LT.PHIEUDATVE
                                                where SqlFunctions.DatePart("year", ptem.NgayDat) == nam
                                                select new
                                                {
                                                    Column1 = (int?)SqlFunctions.DatePart("month", ptem.NgayDat)
                                                }).Min(p => p.Column1)
                                select new
                                {
                                    Column1 = (int?)SqlFunctions.DatePart("month", pr.NgayDat),
                                    pr.DonGia,
                                    Dummy = "x"
                                })
                    group pr by new { pr.Dummy } into g
                    select new
                    {
                        minthang = (int?)g.Min(p => p.Column1),
                        thangdau = (double?)g.Sum(p => p.DonGia)
                    })

                    //============= Lấy Doanh thu của tháng cuối==============
                    from mxth in (from pn in
                                (from pn in LT.PHIEUDATVE
                                    where SqlFunctions.DatePart("year", pn.NgayDat) == nam &&
                                        SqlFunctions.DatePart("month", pn.NgayDat) ==
                                        (from pm in LT.PHIEUDATVE
                                        where SqlFunctions.DatePart("year", pm.NgayDat) == nam
                                            select new
                                        {
                                            Column1 = (int?)SqlFunctions.DatePart("month", pm.NgayDat)
                                        }).Max(p => p.Column1)
                                    select new
                                    {
                                        Column1 = (int?)SqlFunctions.DatePart("month", pn.NgayDat),
                                        pn.DonGia,
                                        Dummy = "x"
                                    })
                        group pn by new { pn.Dummy } into g
                        select new
                        {
                            minthang = (int?)g.Max(p => p.Column1),
                            thangcuoi = (double?)g.Sum(p => p.DonGia)
                        })
                    select new// sql main
                    {
                        tab.Thang,
                        tab.DoanhThu,
                        tab.SoChuyenBay,
                       tyle = 0.01 * Math.Abs((double)(mxth.thangcuoi - mth.thangdau)) / tab.DoanhThu// lấy trị tuyệt đối
                    };
                gridtheonam.ItemsSource = sql.ToList();
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }
        void LoadDS(int thang, int nam)// truy vân báo cáo
        {
            try
            {
                var sql = from tab in (
                                    (from p in LT.PHIEUDATVE// lấy MacB, tên chuyến bay,...
                                     where
                                       SqlFunctions.DatePart("month", p.NgayDat) == thang &&
                                       SqlFunctions.DatePart("year", p.NgayDat) == nam
                                     group new { p, p.CHUYENBAY } by new
                                     {
                                         p.MaCB,
                                         p.CHUYENBAY.TenCB
                                     } into g
                                     select new
                                     {
                                         MaCB = g.Key.MaCB,
                                         g.Key.TenCB,
                                         DoanhThu = (int?)g.Sum(p => p.p.DonGia),
                                         sove = g.Count(p => p.p.MaCB != null)
                                     }))
                          from dtnam in (// lây doanh thu của 12 tháng trong năm đó
                                      (from p in LT.PHIEUDATVE
                                       where SqlFunctions.DatePart("year", p.NgayDat) == nam
                                       group p by new
                                       {
                                           p.MaCB
                                       } into g
                                       select new
                                       {
                                           MaCB = g.Key.MaCB,
                                           DoanhThuNam = (int?)g.Sum(p => p.DonGia)
                                       }))
                          where tab.MaCB == dtnam.MaCB
                          select new
                          {
                              tab.TenCB,
                              tab.MaCB,
                              tab.DoanhThu,
                              tab.sove,
                              tyle = (Double?)(0.01 * tab.DoanhThu / dtnam.DoanhThuNam)
                          };
                if (sql.ToList() != null)
                {
                    gridBC.ItemsSource = sql.ToList();

                }
                else
                {
                    MessageBox.Show("[Tháng " + thang + " rỗng! ]");
                }

            }
            catch (Exception)
            {
                return;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // LoadDS();
            //LoadBV();

            for (int i = 1; i <= 12; i++)
            {
                cbbthang.Items.Add(i);
            }


        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataDSBC?.Invoke("1");// truyền data di cho cac form
        }

        private void gridBC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // select value cbb
        int thang = 0;
        int nam = 0;
        private void cbbthang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thang = int.Parse(cbbthang.SelectedValue.ToString());
            }
            catch (Exception)
            {
                return;
                throw;
            }
            // 
        }

        private void cbbNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnlapBC_Click(object sender, RoutedEventArgs e)
        {
            nam = txtnam.Value;
            LoadDS(thang, nam);
            //   baocaonam(txtBCnam.Value);
            if (thang == 0)
            {
                MessageBox.Show("Bạn Chưa Chọn tháng ");
                return;
            }
            if (gridBC.Items.Count == 0)
            {
                MessageBox.Show("Tháng " + thang + " không có!");
            }
        }

        private void btnxuatBC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlapBCnam_Click(object sender, RoutedEventArgs e)
        {

            baocaonam(txtBCnam.Value);
            if (gridtheonam.Items.Count == 0)
            {
                MessageBox.Show("empty !");
            }
        }
  
    }
}
