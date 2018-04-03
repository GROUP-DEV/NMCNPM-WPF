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
    /// Interaction logic for ThemSanBay.xaml
    /// </summary>
    public partial class ThemSanBay : UserControl
    {
        public delegate void PassData(string s);
        public event PassData DataTSB;
        Cchuyenbay cb = new Cchuyenbay();
        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        public ThemSanBay()
        {
            InitializeComponent();
        }

        void LoadSB()
        {
            //grsbay.ItemsSource = LT.SANBAY.ToList();
            bool check = cb.LoadSB();
            if (check == true)
            {
                gridSB.ItemsSource = cb.CLoadSB;
            }
            else
            {
                return;
            }
        }
        private void gridSB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtmasb.Text = (gridSB.SelectedItem as SANBAY).MaSB;
                txttensb.Text = (gridSB.SelectedItem as SANBAY).TenSB;
            }
            catch (Exception)
            {
                return;
            }
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSB();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataTSB?.Invoke("3");// truyền data di cho cac form
        }

        private void btnthemCB_Click(object sender, RoutedEventArgs e)
        {
            var LT = new QLVeMayBayEntities();

            var check = LT.SANBAY.Where(m => m.MaSB == txtmasb.Text).Count();
            if (txtmasb.Text == "" && txttensb.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhâp mã số và tên sân bay!!");
                return;
            }
            if (txtmasb.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập mã số sân bay!!");
                return;
            }
            if ( txttensb.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhâp tên sân bay!!");
                return;
            }
            Cchuyenbay cb = new Cchuyenbay();
            if (cb.Soluongsanbay() >= 10)
            {
                MessageBox.Show("Số Lượng sân Bay tối đa là 10");
                return;
            }
            else
            {
                if (check > 0)
                {
                    MessageBox.Show("Mã Số đã tồn tại.! kiểm tra lại");
                }
                else
                {
                    var SB = new SANBAY
                    {
                        MaSB = txtmasb.Text,
                        TenSB = txttensb.Text
                    };
                    LT.SANBAY.Add(SB);
                    if (LT.SaveChanges() > 0)
                    {
                        LoadSB();
                        MessageBox.Show("[success ^.^]");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất bại!");
                    }
                }
            }
            
           
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lay thoi gian dung trong database
                string ID = (gridSB.SelectedItem as SANBAY).MaSB;
                var getsb = (LT.SANBAY.Where(m => m.MaSB == ID)).SingleOrDefault();
                getsb.TenSB = getsb.TenSB;
                if (getsb != null)
                {
                    LT.SaveChanges();
                    MessageBox.Show("done!");
                }
                else
                {
                    MessageBox.Show("chưa update được!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("row empty!(^^)");
                return;
            }
        }
    }
}
