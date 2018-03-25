using DoAn.Controller;
using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // CLASS CHUYEN BAY
        Cchuyenbay cb = new Cchuyenbay();
        int temp = 0;
        public chuyenbay()
        {
            InitializeComponent();
        }
        // come back
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataCB?.Invoke("1");// truyền data di cho cac form
        }
        // BACK THEM XOA SUA
        private void backtxs_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            btnthemCB.Background = (Brush)bc.ConvertFrom("#A4BEE0");
            tbtiltle.Text = "NHẬN LỊCH CHUYẾN BAY";
            back.Visibility = Visibility.Visible;
            backtxs.Visibility = Visibility.Collapsed;
            txtchuyenbay.Visibility = Visibility.Collapsed;
            cbbsanbaydi.Visibility = Visibility.Collapsed;
            cbbsanbayden.Visibility = Visibility.Collapsed;
            txtgheh1.Value = 1;
            txtgheh2.Value = 1;
            LoadMaCB();//quay lui nho load lại chuen bay
            txtgheh1.IsEnabled = true;
            txtgheh2.IsEnabled = true;
            dtpicker.IsEnabled = true;
            dtpickerthoigianbay.IsEnabled = true;
            wrsbtg.IsEnabled = true;
            btnxoaCB.IsEnabled = true;// khi nhấn back thì hiên xóa cập nhật đi
            btncapnhatCB.IsEnabled = true;

        }
        // load cbb chuyen bay
        void LoadMaCB()
        {
            //cbbMacb.ItemsSource = LT.CHUYENBAY.ToList();
            bool check = cb.LoadCBBChuyenbay();
            if (check == true)
            {
                cbbMacb.ItemsSource = cb.CloadcbbMacb;
            }
            else
            {
                return;
            }
        }
        // load san bay trung gian
        void LoadSBtrunggian()
        {
            //gridSBTG.ItemsSource = LT.SANBAYTRUNGGIAN.Where(m => m.MaCB == str).ToList();
            bool check = cb.LoadSBtrunggian(valuecbb);
            if (check == true)
            {
                gridSBTG.ItemsSource = cb.CLoadSBtrunggian;
            }
            else
            {
                return;
            }
        }
        void LoadSB()
        {
            //grsbay.ItemsSource = LT.SANBAY.ToList();
            bool check = cb.LoadSB();
            if (check == true)
            {
                grsbay.ItemsSource = cb.CLoadSB;
                cbbsanbayden.ItemsSource = cb.CLoadSB;
                cbbsanbaydi.ItemsSource = cb.CLoadSB;
            }
            else
            {
                return;
            }
        }
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaCB();
            LoadSB();
            // LoadSBtrunggian();
            txtthemsbtg.Visibility = Visibility.Collapsed;// mặc định nó ẩn
        }
        // LAY ID TU COMBOBOX CHUYEN BAY
        string valuecbb = "";// lưu ID khi selectItem combobox
        private void cbbMacb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtpicker.Text = "";
            tberror.Visibility = Visibility.Collapsed;
            try
            {
                valuecbb = cbbMacb.SelectedValue.ToString();
                cbbMacb.Text = valuecbb;
                cb.bingdingCBB(valuecbb);// hàm bingding element
                txtSBDen.Text = cb.tenSBden;
                txtSBDi.Text = cb.TenSBdi;
                dtpicker.Value = DateTime.Parse(cb.ngaygio);

                //dtpicker.SelectedDateFormat = String.Format("{0:M/d/yyyy h:mm:ss tt}", cb.ngaygio);  // "3/9/2008 4:05:07 PM" 
                //dtpicker.SelectedDate = 'dd/MM/yyyy HH:mm:ss';
                dtpickerthoigianbay.Value = DateTime.Parse(cb.Thoigianbay);
                txtgheh1.Value = int.Parse(cb.SLghe1.ToString());
                txtgheh2.Value = int.Parse(cb.SLghe2.ToString());
                // txtTenchuyenbayc.Text = 
                LoadSBtrunggian();
            }
            catch
            {
                return;
            }

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
            //txtngaygio.Visibility = Visibility.Collapsed;
            txtSBDen.Visibility = Visibility.Collapsed;
            txtSBDi.Visibility = Visibility.Collapsed;
            // txttgbay.Visibility = Visibility.Collapsed;
            //cbbMacb.Visibility = Visibility.Collapsed;
            btnsbtg.Visibility = Visibility.Collapsed;
            txtthemsbtg.Visibility = Visibility.Visible;
            btnthemCB.Visibility = Visibility.Collapsed;
            btnxoaCB.Visibility = Visibility.Collapsed;
            btncapnhatCB.Visibility = Visibility.Collapsed;
            btnluulaiCB.Visibility = Visibility.Collapsed;
            dtpicker.Visibility = Visibility.Collapsed;// datepicker ngay - gio bay
            dtpickerthoigianbay.Visibility = Visibility.Collapsed;
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
            //txtngaygio.Visibility = Visibility.Visible;
            txtSBDen.Visibility = Visibility.Visible;
            txtSBDi.Visibility = Visibility.Visible;
            //txttgbay.Visibility = Visibility.Visible;
            // cbbMacb.Visibility = Visibility.Visible;
            btnsbtg.Visibility = Visibility.Visible;
            txtthemsbtg.Visibility = Visibility.Collapsed;
            btnthemCB.Visibility = Visibility.Visible;
            btnxoaCB.Visibility = Visibility.Visible;
            btncapnhatCB.Visibility = Visibility.Visible;
            btnluulaiCB.Visibility = Visibility.Visible;
            dtpicker.Visibility = Visibility.Visible;// dtpicker ngay-gio bay
            dtpickerthoigianbay.Visibility = Visibility.Visible;



        }


        private void btnthemsanbaytrunggian_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ID = (grsbay.SelectedItem as SANBAY).MaSB;// lấy ID từ grid

                if (cb.Soluongsanbaytrunggian(valuecbb) >= 2)
                {
                    tberror.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    tberror.Visibility = Visibility.Collapsed;
                    if (cb.exist(ID, valuecbb) >= 1)// Kiểm tra đã tồn tại nêu  >=1 thì chứng tỏ đã tồn tại zồi ok
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (valuecbb != "")// phải chọn chuyến bay mới tiến hành thục thi ok
                            {
                                cb.themsanbaytrunggian(ID, valuecbb);// hàm them sân bây
                                LoadSBtrunggian();
                                LoadSB();
                            }
                            else
                            {
                                MessageBox.Show("[BẠN CẦN CHỌN CHUYẾN BAY! OK]");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi.bị gì rồi. kiểm tra lại");
                        }
                    }
                }

            }
            catch
            {
                return;
            }
        }

        //cat doan nay 1
        private void btnxoasbtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ID = (gridSBTG.SelectedItem as SANBAYTRUNGGIAN).MaSBTrungGian;
                cb.xoasanbaytrunggian(ID, valuecbb);
                LoadSBtrunggian();
            }
            catch (Exception)
            {
                MessageBox.Show("row empty!(^^)");
                return;
            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lay thoi gian dung trong database
                string ID = (gridSBTG.SelectedItem as SANBAYTRUNGGIAN).MaSBTrungGian;
                cb.capnhatsanbaytrunggian(ID, valuecbb);
            }
            catch (Exception)
            {
                MessageBox.Show("row empty!(^^)");
                return;
            }
        }
        string valuesbdi;
        string valuesbden;
        string masbdi;
        string masbden;
        // int dem = 0;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        private void cbbsanbaydi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var mavaluesbdi = cbbsanbaydi.SelectedValue.ToString();
                var query = LT.SANBAY.Where(m => m.MaSB == mavaluesbdi).SingleOrDefault();
                valuesbdi = query.TenSB;
                masbdi = query.MaSB;
                txtchuyenbay.Text = valuesbdi;
            }
            catch (Exception)
            {
                return;
                //throw;
            }
        }

        // COMBOX SAN BAY DEN
        private void cbbsanbayden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var mavaluesbden = cbbsanbayden.SelectedValue.ToString();
                var query = LT.SANBAY.Where(m => m.MaSB == mavaluesbden).SingleOrDefault();// lấy ra tên san bay
                valuesbden = query.TenSB;
                masbden = query.MaSB;
                if (valuesbdi == valuesbden)// nếu sân bay đến trùng với sân bay đi
                {
                    MessageBox.Show("[CHỌN SÂN BAY ĐẾN KHÁC ĐI!]");
                    cbbsanbayden.Text = "--Chọn sân bay--";
                }
                else
                {
                    //// if (dem==1)
                    {

                        txtchuyenbay.Text = valuesbdi + " - " + valuesbden;
                        //}
                        //else
                        //{
                        //    strSB = " - " + valuesbden;
                        //    txtchuyenbay.Text += strSB;
                        //}

                    }
                }
            }
            catch (Exception)
            {
                return;
                //throw;
            }
        }

        // THÊM CHUYẾN BAY
        private void btnthemCB_Click(object sender, RoutedEventArgs e)
        {
            temp = 1;
            wrsbtg.IsEnabled = false;
            txtchuyenbay.Visibility = Visibility.Visible;
            cbbMacb.ItemsSource = null;
            cbbMacb.Text = "--Chọn chuyến bay--";
            txtchuyenbay.Text = "";
            cbbsanbaydi.Text = "--Chọn sân bay đi--";
            cbbsanbayden.Text = "--Chọn Sân bay đến--";
            cbbsanbaydi.Visibility = Visibility.Visible;
            txtSBDen.Text = "";
            txtSBDi.Text = "";
            cbbsanbayden.Visibility = Visibility.Visible;
            txtgheh1.Value = 1;
            txtgheh2.Value = 1;
            var bc = new BrushConverter();
            btnthemCB.Background = (Brush)bc.ConvertFrom("#007ACC");
            tbtiltle.Text = "THÊM CHUYẾN BAY MỚI";
            back.Visibility = Visibility.Collapsed;
            backtxs.Visibility = Visibility.Visible;
            dtpicker.Value = DateTime.Now;
            //dtpicker.IsEnabled = false;
            dtpickerthoigianbay.Value = DateTime.Now;
            gridSBTG.ItemsSource = null;
            btnxoaCB.IsEnabled = false;// khi nhấn thêm thì ẩn xóa cập nhật đi
            btncapnhatCB.IsEnabled = false;
        }

        private void btnluulaiCB_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var sql = ((from cb in LT.CHUYENBAY
                            orderby
                              cb.MaCB.Substring(cb.MaCB.Length - 4, 4) descending
                            select new
                            {
                                soCB = cb.MaCB.Substring(cb.MaCB.Length - 4, 4)
                            }).Take(1)).FirstOrDefault();
                int soMaxCB = int.Parse(sql.soCB);
                int so = soMaxCB + 1;
                string maso = "000" + so;
                maso = maso.Substring(maso.Length - 4,4);
         
                if (temp == 1)
                {
                    if (txtchuyenbay.Text == "" )
                    {
                        MessageBox.Show("Chưa chọn Sân Bay Đi - Đến!");
                    }
                    else
                    {
                        if (cbbsanbaydi.Text == "--Chọn sân bay đi--")
                        {
                            MessageBox.Show("Vui lòng chọn sân bay đi!");
                        }
                        else
                        {
                            if (cbbsanbayden.Text == "--Chọn Sân bay đến--")
                            {
                                MessageBox.Show("Vui lòng chọn sân bay đến!");
                            }
                            else
                            {
                                var LT = new QLVeMayBayEntities();
                                var sp = new CHUYENBAY
                                {
                                    MaCB = masbdi + "-" + masbden + maso,
                                    TenCB = txtchuyenbay.Text
                                };
                                var LichB = new LICHBAY
                                {
                                    MaCB = masbdi + "-" + masbden + maso,
                                    MaSanBayDi = masbdi,
                                    MaSanBayDen = masbden,
                                    SoLuongGheHang1 = txtgheh1.Value,
                                    SoLuongGheHang2 = txtgheh2.Value,
                                    NgayGio = dtpicker.Value,
                                    ThoiGianBay = dtpickerthoigianbay.Text.ToString(),
                                    // MaSBTrungGian = null,
                                };

                                LT.CHUYENBAY.Add(sp);

                                if (LT.SaveChanges() > 0)
                                {
                                    txtchuyenbay.Text = "";
                                    cbbsanbaydi.Text = "--Chọn sân bay đi--";
                                    cbbsanbayden.Text = "--Chọn Sân bay đến--";

                                    MessageBox.Show("Thêm Thành công");
                                    LT.LICHBAY.Add(LichB);
                                    LT.SaveChanges();
                                    LoadMaCB();
                                }
                                else
                                {
                                    MessageBox.Show("Chưa thêm được!");
                                }
                            }
                        }
                    }
                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("[LỖI THÊM CHUYẾN BAY!]");
            }
        }
        void Matutang()
        {
            //            var query = SELECT Top(1)cast(RIGHT(MaCB, 4) AS Integer) AS soCB
            //FROM CHUYENBAY
            //ORDER BY soCB DESC
            var sql = ((from cb in LT.CHUYENBAY
                        orderby
                          cb.MaCB.Substring(cb.MaCB.Length - 4, 4) descending
                        select new
                        {
                            soCB = cb.MaCB.Substring(cb.MaCB.Length - 4, 4)
                        }).Take(1)).FirstOrDefault();
            int soMaxCB = int.Parse(sql.soCB);
            int chuoi = soMaxCB + 1;
            MessageBox.Show(chuoi.ToString());
        }
        private void btnxoaCB_Click(object sender, RoutedEventArgs e)
        {
            Matutang();
        }

        private void gridSBTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
