using Microsoft.Win32;
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
using System.IO;
using DoAn.Model;
using System.Text.RegularExpressions;
using DoAn.Controller;

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for ThongTinNguoiDung.xaml
    /// </summary>
    public partial class ThongTinNguoiDung : UserControl
    {
        Model.QLVeMayBayEntities BLT = new Model.QLVeMayBayEntities();
        Users uc = new Users();
        Setting Settings = new Setting();
        function fc = new function();
        public ThongTinNguoiDung()
        {
            InitializeComponent();
        }

        public delegate void PassData(string s);
        public event PassData InfoUser;
        public string IdNguoiDung { get; set; }

        string DuongDan = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Title = "Select a picture";
            FileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";

            if (FileDialog.ShowDialog() == true)
            {
                DuongDan = FileDialog.FileName;
                BitmapImage bmp = new BitmapImage(new Uri(DuongDan));
                ImgAvatar.Source = bmp;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string Hoten = txtName.Text;
            string sex = txtSex.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            if (SinhNhat.SelectedDate == null || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Hoten) || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt))
            {
                errorInfo.Text = ("Chưa nhập đầy đủ thông tin!");
                return;
            }
            if (txtSex.Text != "Nam" && txtSex.Text != "Nữ")
            {
                errorInfo.Text = ("Giới tình phải là [Nam] Hoặc [Nữ]!");
                txtSex.Focus();
                return;
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errorInfo.Text = ("Email không hợp lệ");
                txtEmail.Focus();
                return;
            }
            if (sdt.Length > 12 || sdt.Length < 10)
            {
                errorInfo.Text = ("SĐT Phải từ 10 đến 11 số");
                txtSDT.Focus();
                return;
            }
            long sdtparse;
            if (!long.TryParse(txtSDT.Text, out sdtparse))
            {
                errorInfo.Text = ("SĐT không hợp lệ");
                txtSDT.Focus();
                return;
            }
            bool UP = uc.Update_info(txtID.Text, email, sex, Hoten, diachi, sdt, SinhNhat.SelectedDate.Value, DuongDan);// goi ham update
            if (UP == false)
            {
                MessageBox.Show("Fail!");
            }
            else
            {
                MessageBox.Show("Update Success (^.^)!");
                IsReadOnlyTextBox(true);
                errorInfo.Text = ("");
                btnEdit.IsChecked = false;
                InfoUser?.Invoke("1");
            }
        }

        //LOAD IMG AND INFO
        private void LoadIF()
        {
            if (uc.load_info_user(txtID.Text) == true)
            {
                DataContext = uc.Loadinfomation;
            }
            if (uc.LoadInfo(txtID.Text) == true)
            {
                ImgAvatar.Source = uc.sc;// load images avata
            }
            else
            {
                Uri imageUri = new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute);//neu trong database khong co hinh thi mac dinh cho no hin nya
                ImgAvatar.Source = new BitmapImage(imageUri);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            txtID.Text = IdNguoiDung;
            LoadIF();
        }

        private void IsReadOnlyTextBox(bool t)
        {
            txtSex.IsReadOnly = t;
            txtDiaChi.IsReadOnly = t;
            txtEmail.IsReadOnly = t;
            txtSDT.IsReadOnly = t;
            txtName.IsReadOnly = t;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            InfoUser?.Invoke("2");
            Expan.IsExpanded = false;
            Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Checked(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
            IsReadOnlyTextBox(false);
        }

        private void btnEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            IsReadOnlyTextBox(true);
        }

        // CHANGE PASSWOR
        private void SavePasswd_Click(object sender, RoutedEventArgs e)
        {
            string oldpass = fc.md5(pOldPass.Password);
            string newpass =fc.md5(pNewPass.Password);
            string ConfigPass = fc.md5(pPass.Password);

            if (string.IsNullOrEmpty(pOldPass.Password) || string.IsNullOrEmpty(pNewPass.Password) || string.IsNullOrEmpty(pPass.Password))
            {
                error.Content = ("Not fully entered!");
                return;
            }
            else
            {
                uc.getPass(txtID.Text);// get password 
                if (oldpass != uc.getpasswor)
                {
                    error.Content = "Wrong password";
                    return;
                }
                if (newpass != ConfigPass)
                {
                    error.Content = "Confirm password must be same as password.";
                    return;
                }
                bool save_pass = uc.Update_pass(txtID.Text, newpass);
                if (save_pass == false)
                {
                    MessageBox.Show("Fail!");
                    return;
                }
                else
                {
                    MessageBox.Show("Change passwork Success (^.^)!");
                    error.Content = "";
                    Expan.IsExpanded = false;
                }
            }

        }
    }
}
