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
using DTO;
using DAL;


namespace QuanLySanBongDaCauLong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        #region ĐĂNG NHẬP

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string _password = txtPassword.Password;
            string _username = txtUserName.Text;
            if (!string.IsNullOrEmpty(_username) || !string.IsNullOrEmpty(_password))
            {
                if (CheckLogin(_username, _password))
                {
                    Home home = new Home();
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "THÔNG BÁO");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản mật khẩu", "THÔNG BÁO");
            }
        }

        private bool CheckLogin(string username, string password)
        {
            return AccountDAL.Instance.Login(username, password);
        }

        #endregion

        #region Thoát

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion


    }
}
