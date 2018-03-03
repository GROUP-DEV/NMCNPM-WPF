
using DoAn.Controller;
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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : UserControl
    {
        public DangKy()
        {
            InitializeComponent();
        }
        Users uc = new Users();
        public delegate void PassData(int i);
        public event PassData Share;
        function fc = new function();
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            Visibility = Visibility.Collapsed;
            Share?.Invoke(1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            textBoxUser.Clear();
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            Share?.Invoke(2);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Submit_Click(sender, e);
            }
        }

        // regist
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUser.Text.Length == 0)
            {
                errormessage.Text = "Please Enter a Username ";
                textBoxUser.Focus();
                return;
            }
            else if (textBoxUser.Text.Length < 4)
            {
                errormessage.Text = "Please Enter a Username Length >= 5 character!";
                textBoxUser.Focus();
                return;
            }
            // check already exists
            bool exist = uc.exists(textBoxUser.Text);
            if (exist == true)
            {
                errormessage.Text = "The username already exists!";
                textBoxUser.Focus();
                return;
            }
            //----------
            if (textBoxLastName.Text.Length == 0)
            {
                errormessage.Text = "Please Enter at your full name !";
                textBoxLastName.Focus();
                return;
            }
            else if (textBoxLastName.Text.Length < 5)
            {
                errormessage.Text = "Enter a valid your name!";
                textBoxLastName.Focus();
                return;
            }

            //-------------
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Please Enter an email !";
                textBoxEmail.Focus();
                return;
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
                return;
            }
            //----------

            if (passwordBox1.Password.Length == 0)
            {
                errormessage.Text = "Please Enter password !";
                passwordBox1.Focus();
                return;
            }
            if (passwordBoxConfirm.Password.Length == 0)
            {
                errormessage.Text = "Please Enter Confirm password.";
                passwordBoxConfirm.Focus();
                return;
            }
            if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
                passwordBoxConfirm.Focus();
                return;
            }

            string Username = textBoxUser.Text;
            string lastname = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string password = fc.md5(passwordBox1.Password);
            string address = "";
            address = textBoxAddress.Text;
            errormessage.Text = "";

            if (uc.regis(errormessage.Text, Username,password,lastname,email,address)==true)// regist Success
            {
                MessageBox.Show("regist Success (^.^)!");
                Reset();
            }
            else
            {
                MessageBox.Show("Error Please record");
            }
        }


    }
}
