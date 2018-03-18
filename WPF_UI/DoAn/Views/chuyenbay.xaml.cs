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
        int temp=0;
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
            LoadMaCB();//quay lui nho load lại chuen bay
            txtgheh1.IsEnabled = true;
            txtgheh2.IsEnabled = true;
            dtpicker.IsEnabled = true;
            dtpickerthoigianbay.IsEnabled = true;
            wrsbtg.IsEnabled = true;
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
        int valuecbb = 0;// lưu ID khi selectItem combobox
        private void cbbMacb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtpicker.Text = "";
            tberror.Visibility = Visibility.Collapsed;
            try
            {
                valuecbb = int.Parse(cbbMacb.SelectedValue.ToString());
                cb.bingdingCBB(valuecbb);// hàm bingding element
                txtSBDen.Text = cb.tenSBden;
                txtSBDi.Text = cb.TenSBdi;
                dtpicker.Value = DateTime.Parse(cb.ngaygio);

                //dtpicker.SelectedDateFormat = String.Format("{0:M/d/yyyy h:mm:ss tt}", cb.ngaygio);  // "3/9/2008 4:05:07 PM" 
                //dtpicker.SelectedDate = 'dd/MM/yyyy HH:mm:ss';
                dtpickerthoigianbay.Value = DateTime.Parse(cb.Thoigianbay);
                txtgheh1.Value = int.Parse(cb.SLghe1);
                txtgheh2.Value = int.Parse(cb.SLghe2);
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
                            if (valuecbb != 0)// phải chọn chuyến bay mới tiến hành thục thi ok
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
        string strSB = "";
        string valuesbdi;
        string valuesbden;
        // int dem = 0;
        private void cbbsanbaydi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                valuesbdi = cbbsanbaydi.SelectedValue.ToString();
                strSB = valuesbdi;
                txtchuyenbay.Text = strSB;
            }
            catch (Exception)
            {
                return;
                //throw;
            }

        }

        private void cbbsanbayden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {

                valuesbden = cbbsanbayden.SelectedValue.ToString();
                if (valuesbdi == valuesbden)
                {
                    MessageBox.Show("[CHỌN SÂN BAY ĐẾN KHÁC ĐI]");

                }
                else
                {
                    //// if (dem==1)
                    {
                        strSB = " - " + valuesbden;
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
            txtchuyenbay.Visibility = Visibility.Visible;
            cbbMacb.ItemsSource = null;
            cbbMacb.Text = "--Chọn chuyến bay--";
            cbbsanbaydi.Visibility = Visibility.Visible;
            txtSBDen.Text = "";
            txtSBDi.Text = "";
            cbbsanbayden.Visibility = Visibility.Visible;
            txtgheh1.Value = 1;
            txtgheh1.IsEnabled = false;
            txtgheh2.Value = 1;
            txtgheh2.IsEnabled = false;
            //  btnthemCB.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0));
            var bc = new BrushConverter();
            btnthemCB.Background = (Brush)bc.ConvertFrom("#007ACC");
            tbtiltle.Text = "THÊM CHUYẾN BAY MỚI";
            back.Visibility = Visibility.Collapsed;
            backtxs.Visibility = Visibility.Visible;
            dtpicker.Value = DateTime.Now;
            dtpicker.IsEnabled = false;
            dtpickerthoigianbay.Value = new DateTime(0);
            dtpickerthoigianbay.IsEnabled = false;
            //ObservableCollection<SANBAYTRUNGGIAN> SBTG = new ObservableCollection<SANBAYTRUNGGIAN>();
            gridSBTG.ItemsSource = null;
            wrsbtg.IsEnabled = false;
        }

        private void btnluulaiCB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random ran = new Random();
                int so = ran.Next(123, 98765);
                if (temp == 1)
                {
                    var LT = new QLVeMayBayEntities();
                   // var CB = LT.CHUYENBAY.FirstOrDefault();
                    var sp = new CHUYENBAY
                    {
                        MaCB = so,
                        TenCB = txtchuyenbay.Text

                    };

                    LT.CHUYENBAY.Add(sp);
                    if (LT.SaveChanges() > 0)
                    {

                        MessageBox.Show("Thêm Thành công");

                    }
                    else
                    {
                        MessageBox.Show("Chưa thêm được!");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("[LỖI THÊM CHUYẾN BAY!]");
            }
        }
    }
}
