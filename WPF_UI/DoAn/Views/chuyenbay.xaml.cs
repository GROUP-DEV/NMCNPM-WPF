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
    /// Interaction logic for chuyenbay.xaml
    /// </summary>
    public partial class chuyenbay : UserControl
    {
        public delegate void PassData(string s);
        public event PassData DataCB;
        // CONNECT DATABSE
        // CLASS CHUYEN BAY
        Cchuyenbay cb = new Cchuyenbay();
        public chuyenbay()
        {
            InitializeComponent();
        }
        // come back
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataCB?.Invoke("1");// truyền data di cho cac form
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
            tberror.Visibility = Visibility.Collapsed;
            valuecbb = int.Parse(cbbMacb.SelectedValue.ToString());
            cb.bingdingCBB(valuecbb);// hàm bingding element
            txtSBDen.Text = cb.tenSBden;
            txtSBDi.Text = cb.TenSBdi;
            txtngaygio.Text = cb.ngaygio;
            txttgbay.Text = cb.Thoigianbay;
            txtgheh1.Text = cb.SLghe1;
            txtgheh2.Text = cb.SLghe2;
            LoadSBtrunggian();
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
            btnsbtg.Visibility = Visibility.Collapsed;
            txtthemsbtg.Visibility = Visibility.Visible;
            btnthemCB.Visibility = Visibility.Collapsed;
            btnxoaCB.Visibility = Visibility.Collapsed;
            btncapnhatCB.Visibility = Visibility.Collapsed;
            btnluulaiCB.Visibility = Visibility.Collapsed;
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
            btnsbtg.Visibility = Visibility.Visible;
            txtthemsbtg.Visibility = Visibility.Collapsed;
            btnthemCB.Visibility = Visibility.Visible;
            btnxoaCB.Visibility = Visibility.Visible;
            btncapnhatCB.Visibility = Visibility.Visible;
            btnluulaiCB.Visibility = Visibility.Visible;

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
                    if (cb.exist(ID,valuecbb) >= 1)// Kiểm tra đã tồn tại nêu  >=1 thì chứng tỏ đã tồn tại zồi ok
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
                //QLVeMayBayEntities LT = new QLVeMayBayEntities();
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
        private void cbbsanbaydi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbbsanbayden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
