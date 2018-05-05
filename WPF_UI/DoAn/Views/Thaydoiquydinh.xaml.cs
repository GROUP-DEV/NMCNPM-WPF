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
    /// Interaction logic for Thaydoiquydinh.xaml
    /// </summary>
    public partial class Thaydoiquydinh : UserControl
    {
        //truyen du lieu to window plane
        public delegate void PassData(string s);
        public event PassData DataTDQD;
        QLVeMayBayEntities LT = new QLVeMayBayEntities();
        public Thaydoiquydinh()
        {
            InitializeComponent();
            load();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            DataTDQD?.Invoke("1");// truyền data di cho cac form
        }
        private void load()
        {
            boxslsbtoida.Value=0;
           boxslsbtgtoida.Value=0;
            dtpickerthoigianbay.Text="00:00:00";
            boxtgdungtoithieu.Value=0;
             boxtgdungtoida.Value=0;
            var lb = (LT.THAYDOIQUYDINH.Where(m => m.STT == 1)).Single();
            boxslsbtoida.Value= int.Parse(lb.SLSanBay.ToString());
            boxslsbtgtoida.Value=int.Parse( lb.SoSBTGToiDa.ToString());
            dtpickerthoigianbay.Text= lb.TGBayToiThieu;
            boxtgdungtoithieu.Value =int.Parse( lb.TGDungToiThieu.ToString());
            boxtgdungtoida.Value = int.Parse(lb.TGDungToiDa.ToString());
        }
        private void btncapnhat_Click(object sender, RoutedEventArgs e)
        {
            QLVeMayBayEntities LT = new QLVeMayBayEntities();
            Thaydoiquydinh tdq = new Thaydoiquydinh();
            try
            {
                
                    var lb = (LT.THAYDOIQUYDINH.Where(m => m.STT == 1)).Single();
                    lb.SLSanBay = boxslsbtoida.Value;
                    lb.SoSBTGToiDa = boxslsbtgtoida.Value;
                    lb.TGBayToiThieu = dtpickerthoigianbay.Text.ToString();
                    lb.TGDungToiThieu = boxtgdungtoithieu.Value;
                    lb.TGDungToiDa = boxtgdungtoida.Value;
                    if (lb != null)
                    {
                        LT.SaveChanges();
                    
                        load();
                        MessageBox.Show("done!");
                         
                     }
                    else
                    {
                        MessageBox.Show("chưa update được!");
                    }
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
