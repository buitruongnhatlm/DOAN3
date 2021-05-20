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
using System.Data;
using System.Text.RegularExpressions;

namespace QuanLySanBongDaCauLong.Views
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            LoadData();
            LoadDataToCombobox();
        }

        #region ACCOUNT

        public void LoadData()
        {
            dtgAccount.ItemsSource = AccountDAL.Instance.GetListAccount().DefaultView;
            dtgAccountType.ItemsSource = AccountTypeDAL.Instance.GetListAccountType().DefaultView;
        }

        public void LoadDataToCombobox()
        {
            cbbLoaiTaiKhoan.ItemsSource = AccountTypeDAL.Instance.GetListAccountTypeToCombobox();
            cbbLoaiTaiKhoan.DisplayMemberPath = "AccountTypeName";
        }

        private void dtgAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid _dataGrid = sender as DataGrid;
            DataRowView _dataRow = _dataGrid.SelectedItem as DataRowView;

            if(_dataGrid != null && _dataRow !=null)
            {
                txtTenTaiKhoan.Text = _dataRow["UserName"].ToString();
                txtMatKhau.Text = _dataRow["PassWord"].ToString();
                txtGhiChu.Text = _dataRow["Note"].ToString();
                cbbLoaiTaiKhoan.Text = _dataRow["AccountTypeName"].ToString();
            }

        }

        public bool CheckDataInput(string username, string password)
        {
            string _patternEmail = "^[a-zA-Z0-9]{3,20}@[a-zA-Z0-9]{2,10}.[a-zA-Z]{2,3}$";
            string _patternTenTaiKhoan = @"^[a-zA-Z0-9_]{5,24}$";
            string _patternSoDienThoai = @"^(01|03|05|07|08|09)+(-)+(\d{4}-\d{4})$";

            Regex _regexEmail = new Regex(_patternEmail);
            Regex _regexTenTaiKhoan = new Regex(_patternTenTaiKhoan);
            Regex _regexSoDienThoai = new Regex(_patternSoDienThoai);

            if ( _regexTenTaiKhoan.IsMatch(username) && ValidatePassword(password))
            {
                return true;
            }
            else
            {
                CustomMessageBox.Show("Thông Báo", "Thông tin đã nhập không đúng định dạng! Vui lòng kiểm tra lại", MessageBoxButton.OK);
                return false;
            }

        }

        public void AddAccount(string username, string password, int accounttype, string note = null)
        {
            if (AccountDAL.Instance.InsertAccount(username, password, accounttype, note))
            {
                CustomMessageBox.Show("Thông Báo", "Thêm tài khoản thành công", MessageBoxButton.OK);
            }

            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

            LoadData();

        }

        public void EditAccount(string username, string password, int accounttype, string note = null)
        {
            if (AccountDAL.Instance.UpdateAccount(username, password, accounttype, note))
            {
                CustomMessageBox.Show("Thông Báo", "Cập nhật thông tin tài khoản thành công", MessageBoxButton.OK);
            }

            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

            LoadData();
        }

        public void DeleteAccount(string username)
        {
            if (AccountDAL.Instance.DeleteAccount(username))
            {
                CustomMessageBox.Show("Thông Báo", "Xóa tài khoản thành công", MessageBoxButton.OK);
            }
            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

            LoadData();

        }

        public void SearchAccount(string content, int typeSearch)
        {
            if(typeSearch == 0)
            {
                dtgAccount.ItemsSource = AccountDAL.Instance.SearchAccountByUserName(content).DefaultView;
            }
            else if(typeSearch == 1)
            {
                dtgAccount.ItemsSource = AccountDAL.Instance.SearchAccountByNote(content).DefaultView;
            }
        }

        #region KIỂM TRA MẬT KHẨU
        private bool ValidatePassword(string password)
        {

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng");
            }

            var _patternNumber = new Regex(@"[0-9]+");
            var _patternUpperChar = new Regex(@"[A-Z]+");
            var _patternLowerChar = new Regex(@"[a-z]+");
            var _patternMaxChars = new Regex(@".{6,25}");

            if (!_patternLowerChar.IsMatch(password))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 kí tự viết thường");
                return false;
            }
            else if (!_patternUpperChar.IsMatch(password))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 kí tự viết hoa");
                return false;
            }
            else if (!_patternMaxChars.IsMatch(password))
            {
                MessageBox.Show("Mật khẩu phải có độ dài từ 6 đến 25 kí tự");
                return false;
            }
            else if (!_patternNumber.IsMatch(password))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 kí tự số");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private void btnThemTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            string _username = txtTenTaiKhoan.Text;
            string _password = txtMatKhau.Text;
            string _note = txtGhiChu.Text;
            int _accounttype = 1;

            if (cbbLoaiTaiKhoan.SelectedIndex != -1)
            {
                _accounttype = cbbLoaiTaiKhoan.SelectedIndex + 1;
            }
            else
            {
                _accounttype = 1;
            }

            if (CheckDataInput(_username, _password))
            {
                AddAccount(_username, _password, _accounttype, _note);
            }


        }

        private void btnCapNhatTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            string _username = "";
            string _password = txtMatKhau.Text;
            string _note = txtGhiChu.Text;
            int _accounttype = 1;

            if (cbbLoaiTaiKhoan.SelectedIndex != -1)
            {
                _accounttype = cbbLoaiTaiKhoan.SelectedIndex + 1;
            }
            else
            {
                _accounttype = 1;
            }

            DataRowView _rowCurrent = dtgAccount.SelectedItem as DataRowView;
            if (_rowCurrent != null)
            {
                _username = _rowCurrent["UserName"].ToString();
            }

            if (CheckDataInput(_username, _password))
            {
                EditAccount(_username, _password, _accounttype, _note);
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            string _username = "";
            DataRowView _rowCurrent = dtgAccount.SelectedItem as DataRowView;
            if (_rowCurrent != null)
            {
                var messageBoxResult = CustomMessageBox.Show("Thông báo", "Bạn có chắc xóa không?", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes) 
                {
                    _username = _rowCurrent["UserName"].ToString();
                    DeleteAccount(_username);
                    txtTenTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtGhiChu.Text = "";
                }
            }
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (cbbLoaiTimKiem.SelectedIndex == 0)
            {
                SearchAccount(txtSearch.Text,0);
            }
            else if (cbbLoaiTimKiem.SelectedIndex == 1)
            {
                SearchAccount(txtSearch.Text,1);
            }

        }

        #endregion

        private void btnThemLoaiTaiKhoan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCapNhatLoaiTaiKhoan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXoaLoaiTaiKhoan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
