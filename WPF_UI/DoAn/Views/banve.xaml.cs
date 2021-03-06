﻿using DoAn.Controller;
using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        IQueryable<PHIEUDATVE> SourceFill;// SOURCE PAGES

        public banve()
        {
            InitializeComponent();
            var db = this.FindResource("dbForWd") as Pages;// SET PAGES CURR
            db.CurPage = 1;
            // ham kiem tra
            checbox();
            cbbhangve.IsEnabled = false;
            LoadMaCB();
            LoadLoaive();
            LoadBV();
            loadtrang();
        }
        void checbox()
        {
            // ham kiem tra
            checkF v = new checkF();
            v.Phone = "";
            v.Email = "";
            v.CMND = "";
            DataContext = v;
        }
        void LoadBV()
        {
            //var sql = (from cb in LT.PHIEUDATVE
            //                      orderby
            //                        cb.MaCB.Substring(cb.MaCB.Length - 4, 4) descending
            //                      select new
            //                      {
            //                          DienThoai1 = cb.DienThoai,
            //                          MaLoai1 = cb.MaLoai,
            //                          DonGia1 = cb.DonGia,
            //                          NgayDat1 = cb.NgayDat,
            //                          TenHanhKhach1 = cb.TenHanhKhach,
            //                          MaCB1 = cb.MaCB,
            //                          soCB = cb.MaCB.Substring(cb.MaCB.Length - 4, 4)
            //                      });
            //gridBV.DataContext = sql.ToList();
            var sql = from PHIEUDATVE in LT.PHIEUDATVE
                      orderby PHIEUDATVE.STT
                      select PHIEUDATVE;
            gridBV.ItemsSource = sql.ToList();
        }
        void loadtrang()
        {
            // START LOAD PAGES
            SourceFill = LT.PHIEUDATVE;
            var db = this.FindResource("dbForWd") as Pages;
            int totalPage;
            db.CurPage = 1;
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ButtunPage(totalPage);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaCB();
            LoadLoaive();
            LoadBV();
            loadtrang();
            checbox();

        }
        string valuecbb ;
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataCB?.Invoke("1");// truyền data di cho cac form
        }
        void LoadMaCB()
        {
            cbbMacb.ItemsSource = LT.CHUYENBAY.ToList();
        }
        void LoadLoaive()
        {
            cbbhangve.ItemsSource = LT.LOAIVE.ToList();
        }
        int? soluongghetrong;
       
        //==BÁN VÉ
        private void btnbanve_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var LT = new QLVeMayBayEntities();

                if (cbbMacb.Text == "--Chọn chuyến bay--" || cbbhangve.Text == "--Chọn Hạng Vé--" || txtcmnd.Text == "" || txtdienthoai.Text == "" || txthanhkhach.Text == "")
                {
                    MessageBox.Show("Bạn Chưa chọn đủ");
                }
                else
                {
                    int ma = int.Parse(cbbhangve.SelectedValue.ToString());
                    // lấy số trong mã chữ
                    LICHBAY query = LT.LICHBAY.Where(m => m.MaCB == cbbMacb.SelectedValue.ToString()).FirstOrDefault();// update lai so luong ghe
                    DANHSACHCHUYENBAY ds = LT.DANHSACHCHUYENBAY.Where(m => m.MaCB == cbbMacb.SelectedValue.ToString()).FirstOrDefault();
                    int cmnd = LT.PHIEUDATVE.Where(m => m.CMND == txtcmnd.Text.ToString()).Count();

                    int? tongsoghe = query.SoLuongGheHang1 + query.SoLuongGheHang2;
                    var sql = ((from cb in LT.CHUYENBAY
                                where cb.MaCB == cbbMacb.SelectedValue.ToString()
                                orderby
                                  cb.MaCB.Substring(cb.MaCB.Length - 4, 4) descending
                                select new
                                {
                                    soCB = cb.MaCB.Substring(cb.MaCB.Length - 4, 4)
                                }).Take(1)).FirstOrDefault();
                    int soMaxCB = int.Parse(sql.soCB);
                    var PDV = new PHIEUDATVE
                    {
                        MaCB = cbbMacb.SelectedValue.ToString(),
                        TenHanhKhach = txthanhkhach.Text,
                        CMND = txtcmnd.Text,
                        DienThoai = txtdienthoai.Text,
                        DonGia = int.Parse(txtgiave.Text.ToString()),
                        //DonGia = int.Parse(String.Format("{0:0,0}", txtgiave.Text)),
                        MaLoai = cbbhangve.SelectedValue.ToString(),
                        NgayDat = datepk.SelectedDate,
                        STT = soMaxCB,
                    };

                    LT.PHIEUDATVE.Add(PDV);
                    if (query.NgayGio <= DateTime.Now)
                    {
                        MessageBox.Show("[Sorry. Chuyến bay này đã Khởi Hành!!]");
                        return;
                    }
                    if (cmnd > 0)// kiểm tra đã tồn tại
                    {
                        MessageBox.Show("Số CMND :[" +txtcmnd.Text+ "] đã tồn tại!");
                        return;
                    }
                    else
                    {
                        if (ma == 1)// nếu hạng vé là hạng 1
                        {
                            if (query.SoLuongGheHang1 == 0)// nếu ghế đã hết
                            {
                                MessageBox.Show("[Số Ghế Hang 1 Đã Hết]!");
                                return;
                            }
                            else
                            {
                                LT.SaveChanges();
                                query.SoLuongGheHang1 = query.SoLuongGheHang1 - 1;
                                ds.SoLuongGheTrong = query.SoLuongGheHang1 + query.SoLuongGheHang2;// sôlượng ghế trống
                                ds.SoLuongGheDat = ds.SoLuongGheDat + 1;// sốlượng ghế đặt
                                LT.SaveChanges();
                                MessageBox.Show("bán Thành công");
                                cbbhangve.Text = "--Chọn Hạng Vé--";
                                txtgiave.Text = "0";
                                txtsoluongghetrong.Text = "";
                                txtcmnd.IsReadOnly = true;
                            }
                        }
                        else// ngược lại thôi ok
                        {
                            if (query.SoLuongGheHang2 == 0)
                            {
                                MessageBox.Show("[Số Ghế Hang 2 Đã Hết]!");
                                return;
                            }
                            else
                            {
                                LT.SaveChanges();
                                query.SoLuongGheHang2 = query.SoLuongGheHang2 - 1;
                                ds.SoLuongGheTrong = tongsoghe - 1;// sôlượng ghế trống
                                ds.SoLuongGheDat = ds.SoLuongGheDat + 1;// cập nhật lại số ghế đặt
                                                                        //ds.SoLuongGheDat = tongsoghe - ds.SoLuongGheTrong;// sốlượng ghế đặt
                                LT.SaveChanges();
                                MessageBox.Show("bán Thành công");
                                cbbhangve.Text = "--Chọn Hạng Vé--";
                                txtgiave.Text = "0";
                                txtsoluongghetrong.Text = "";
                                txtcmnd.IsReadOnly = true;
                            }
                        }
                    }
                  
                    //LoadBV();
                    loadtrang();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Chưa Bán được!");
                return;
            }

        }

        private void cbbMacb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                cbbhangve.IsEnabled = true;
                valuecbb = cbbMacb.SelectedValue.ToString();
                var query = (from lb in LT.LICHBAY
                            from cb in LT.CHUYENBAY
                            where lb.MaCB ==cb.MaCB && cb.MaCB ==valuecbb
                            select new
                            {
                                cb.TenCB,
                                lb.MaCB,
                                lb.NgayGio,
                                lb.ThoiGianBay,
                                lb.SoLuongGheHang1,
                                lb.SoLuongGheHang2
                            }).FirstOrDefault();
                cbbMacb.Text = query.MaCB;
                txtngaygio.Text = query.NgayGio.ToString();
                txttgbay.Text = query.ThoiGianBay.ToString();
                soluongghetrong = query.SoLuongGheHang1 + query.SoLuongGheHang2;
                txtsoluongghetrong.Text = soluongghetrong.ToString();
                LoadLoaive();
                cbbhangve.Text = "--Chọn Hạng Vé--";
                txtgiave.Text = "0";
            }
            catch (Exception)
            {
                // MessageBox.Show("!!!"); khi nhấn btnres_Click(object sender, RoutedEventArgs e) fild err
                return;
            }

        }

        private void gridBV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string ID = (gridBV.SelectedItem as PHIEUDATVE).MaCB;
                string IDma = (gridBV.SelectedItem as PHIEUDATVE).MaLoai;

                var qr = LT.LICHBAY.Where(m => m.MaCB == ID).SingleOrDefault();
                cbbMacb.Text = qr.MaCB;
                txttgbay.Text = qr.ThoiGianBay;
                txtngaygio.Text = qr.NgayGio.ToString();
                cbbhangve.Text = IDma;
                txtcmnd.Text = (gridBV.SelectedItem as PHIEUDATVE).CMND;
                txtdienthoai.Text = (gridBV.SelectedItem as PHIEUDATVE).DienThoai;
                txthanhkhach.Text = (gridBV.SelectedItem as PHIEUDATVE).TenHanhKhach;
                datepk.Text = (gridBV.SelectedItem as PHIEUDATVE).NgayDat.ToString();
                txtgiave0.Text= String.Format("{0:0,0 VNĐ}", (gridBV.SelectedItem as PHIEUDATVE).DonGia);
                txtgiave.Text = (gridBV.SelectedItem as PHIEUDATVE).DonGia.ToString();
                txtcmnd.IsReadOnly = true;
            }
            catch (Exception)
            {
                return;
            }

        }

        // SELECT COMBOX HANGVE
        private void cbbhangve_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string maloai = cbbhangve.SelectedValue.ToString();// lay ma loai ve tu cbb
                                                                   // var query = LT.LICHBAY.Where(m => m.MaCB == valuecbb).FirstOrDefault();// gia tri de ss neu chua chon chuyen bay
                var query = (from lb in LT.LICHBAY
                             from cb in LT.CHUYENBAY
                             where lb.MaCB == cb.MaCB && cb.MaCB == valuecbb
                             select new
                             {
                                 cb.TenCB,
                                 lb.MaCB,
                                 lb.NgayGio,
                                 lb.ThoiGianBay,
                                 lb.SoLuongGheHang1,
                                 lb.SoLuongGheHang2
                             }).FirstOrDefault();
                var layDG = LT.LOAIVE.Where(m => m.MaLoai == maloai).FirstOrDefault();// lay ten ma loai

                if (maloai == "1")// neu bang 1 thi thu thi theo nó ok
                {
                    txtsoluongghetrong.Text = query.SoLuongGheHang1.ToString();
                    txtgiave.Text = layDG.DonGia.ToString();
                    txtgiave0.Text = String.Format("{0:0,0 VNĐ}", layDG.DonGia);
                }
                else
                {
                    txtsoluongghetrong.Text = query.SoLuongGheHang2.ToString();
                    txtgiave.Text = layDG.DonGia.ToString();
                    txtgiave0.Text = String.Format("{0:0,0 VNĐ}", layDG.DonGia);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("ERROR");
            }

        }
        private void btnres_Click(object sender, RoutedEventArgs e)
        {
            cbbMacb.Text = "--Chọn chuyến bay--";
            txtngaygio.Text = "";
            txtsoluongghetrong.Text = "0";
            txttgbay.Text = "";
            txthanhkhach.Text = "";
            txtgiave.Text = "0";
            txtdienthoai.Text = "";
            txtcmnd.Text ="";
            datepk.Text = DateTime.Now.ToString();
            cbbhangve.Text = "--Chọn hang ve--";
            txtcmnd.IsReadOnly = false;
        }

        //======================================================SATRT PAGEs==================================
    
        private void gridSBTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        // CẬP NHẬT VE chưa test
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbbMacb.Text == "--Chọn chuyến bay--")
                {
                    MessageBox.Show("Bạn Chưa Chọn chuyến bay cần cập nhật!!");
                }
                else
                {
                    var cmnd = LT.PHIEUDATVE.Where(m => m.CMND == txtcmnd.Text.ToString()).SingleOrDefault();
                    //var lb = (LT.PHIEUDATVE.Where(m => m.MaCB == valuecbb)).SingleOrDefault();        
                    cmnd.DienThoai = txtdienthoai.Text;
                 
                    if (cmnd != null)
                    {
                        LT.SaveChanges();
                        MessageBox.Show("done!");
                    }
                    else
                    {
                        MessageBox.Show("chưa update được!");
                    }
                }

            }
            catch (Exception)
            {

                return;
            }
        }

        // START PAGES
        List<PHIEUDATVE> GetSearchQuery(int curPage, int pageSize, out int totalPage)
        {
            IQueryable<PHIEUDATVE> q = SourceFill;

            totalPage = (int)Math.Ceiling(q.Count() * 1.0 / pageSize);
            gridBV.ItemsSource = q.OrderBy(p => p.STT).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return q.OrderBy(c => c.STT).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
        }
        private void ButtunPage(int total)
        {
            int totalPage = total;
            List<PageButton> ListBtn = new List<PageButton>();
            PageButton t;
            for (int i = 0; i < totalPage; i++)
            {
                t = new PageButton();
                t.I = i + 1;
                ListBtn.Add(t);
            }
            ListButton.ItemsSource = ListBtn;

        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("dbForWd") as Pages;
            int temp;
            int totalPage;
            if (db.CurPage > 1 && int.TryParse(btnInPage.Text, out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            {
                db.CurPage--;
            }
            else { return; }
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ListButton.SelectedIndex = db.CurPage - 1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("dbForWd") as Pages;

            int totalPage;
            int temp;
            if (db.CurPage < db.TotalPage && int.TryParse(btnInPage.Text, out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            {
                db.CurPage++;
            }
            else
            {
                return;
            }
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ListButton.SelectedIndex = db.CurPage - 1;
        }


        private void btnInPage_KeyDown(object sender, KeyEventArgs e)
        {
            int n;
            if (!int.TryParse(btnInPage.Text, out n))
            {
                n = 1;
            }
            else if (n <= Convert.ToInt32(txtTotal.Text) && n >= 1)
            {
                var db = this.FindResource("dbForWd") as Pages;

                int totalPage;

                db.CurPage = n;

                db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
                db.TotalPage = totalPage;
                ListButton.SelectedIndex = n - 1;
            }
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;

            PageButton D = temp.DataContext as PageButton;
            int Id = D.I;
            var db = this.FindResource("dbForWd") as Pages;
            ListButton.SelectedIndex = Id - 1;
            int totalPage;

            db.CurPage = Id;

            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
        }

        // sự kiện text change cho text box
        private void txtdienthoai_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtcmnd.Text.Count() == 9  && txtdienthoai.Text.Count() >= 10 && txtdienthoai.Text.Count() <= 11)
            {
                btnbanve.IsEnabled = true;
            }
            else
            {
                btnbanve.IsEnabled = false;
            }
        }
        // Mặc định không cho nhập chữ ở ô text sđt and cmnd
        private void txtdienthoai_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        // XOA PHIEU DAT VE
        private void btnxoasbtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ID = (gridBV.SelectedItem as PHIEUDATVE).CMND;
                var xoa = (LT.PHIEUDATVE.Where(m => m.CMND == ID )).SingleOrDefault();
                if (xoa != null)
                {
                    if (MessageBox.Show("BẠN CHẮC CHƯA?", "            THÔNG BÁO    ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        LT.PHIEUDATVE.Remove(xoa);
                        LT.SaveChanges();
                        loadtrang();
                    }
                }
                else
                {
                    MessageBox.Show("[KHÔNG LÂY ĐƯƠC MÃ SÂN BAY!]");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("row empty!(^^)");
                return;
            }
        }



        // ========================END PAGES========================
    }
}
