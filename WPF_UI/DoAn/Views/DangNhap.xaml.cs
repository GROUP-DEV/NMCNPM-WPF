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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    /// 
    public partial class DangNhap : UserControl
    {
        
        public DangNhap()
        {
            InitializeComponent();
        }
        Users cn = new Users();
        public delegate void PassData(string s);// Send data 
        public event PassData share;
        public event PassData _Registration;
        function fc = new function();
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtName.Text;
            string Pass = txtPasswd.Password;
            Pass = fc.md5(Pass);// Mã Hóa MD5

            bool check=cn.login_uc(Name,Pass);// Hàm login
            if (txtName.Text == "" && txtPasswd.Password == "")
            {
                errormessage.Text = "Chưa Nhập Tài Khoản Và Mật Khẩu";
            }
            else
            {
                if (txtName.Text != "" && txtPasswd.Password == "")
                {
                    errormessage.Text = "Chưa Nhập Mật Khẩu";
                }
                else if (txtName.Text != "" && txtPasswd.Password != "")
                {
                    if (check == true)
                    {
                        //MessageBox.Show(cn.IDUser.ToString());
                        share?.Invoke(cn.IDUser);// send IDuser
                        Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        errormessage.Text = "Sai Tài Khoản Hoặc Mật Khẩu";
                    }
                }
                else
                {
                    errormessage.Text = "Chưa Nhập Tài Khoản";
                }
            }
        }

        // đăng ký
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            _Registration?.Invoke("1");
            Visibility = Visibility.Collapsed;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                txtName.Clear();
                txtPasswd.Clear();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            _Registration?.Invoke("2");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }
    }
}
