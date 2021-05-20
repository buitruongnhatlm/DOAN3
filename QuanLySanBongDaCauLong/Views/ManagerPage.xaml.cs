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
using DAL;
using DTO;
using System.Data;

namespace QuanLySanBongDaCauLong.Views
{
    /// <summary>
    /// Interaction logic for ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            LoadDataToDatagridManager();
        }

        public void LoadDataToDatagridManager()
        {
            dtgManager.ItemsSource = ManagerDAL.Instance.GetListManager().DefaultView;
        }

        private void GetValueFromSelectedRowChangedSoccer(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name;
                DateTime _Birthday;
                string _Sex;
                int _IdentityNumber;
                string _BirthPlace;
                string _Address;
                int _NumberPhone;
                string _Email;
                string _Note="";
                string _Account;
                string _Department;

                _Name = dataRow.Row.ItemArray[1].ToString();
                _Birthday = Convert.ToDateTime(dataRow.Row.ItemArray[2].ToString());
                _Sex = dataRow.Row.ItemArray[3].ToString();
                _IdentityNumber = Convert.ToInt32(dataRow.Row.ItemArray[4].ToString());
                _BirthPlace = dataRow.Row.ItemArray[5].ToString();
                _Address = dataRow.Row.ItemArray[6].ToString();
                _NumberPhone = Convert.ToInt32(dataRow.Row.ItemArray[7].ToString());
                _Email = dataRow.Row.ItemArray[8].ToString();
                _Note = dataRow.Row.ItemArray[9].ToString();
                _Account = dataRow.Row.ItemArray[10].ToString();
                _Department = dataRow.Row.ItemArray[11].ToString();

                txtTenNhanVien.Text = _Name;
                dtpNgaySinh.Text = _Birthday.ToString();
                txtGioiTinh.Text = _Sex;
                txtChungMinhNhanDan.Text = _IdentityNumber.ToString();
                txtNoiSinh.Text = _BirthPlace;
                txtDiaChi.Text = _Address;
                txtSoDienThoai.Text = _NumberPhone.ToString();
                txtEmail.Text = _Email;
                txtNote.Text = _Note;
                txtTaiKhoan.Text = _Account;
                txtBoPhan.Text = _Department;

            }
            catch { }

        }

    }
}
