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
    /// Interaction logic for MedicalPage.xaml
    /// </summary>
    public partial class MedicalPage : Page
    {
        public MedicalPage()
        {
            InitializeComponent();
            LoadData();
        }

        #region LoadData

        public void LoadData()
        {
            LoadDataToDatagridMedical();
            LoadDataToDatagridDepartment();
        }

        public void LoadDataToDatagridMedical()
        {
            dtgMedical.ItemsSource = MedicalDAL.Instance.GetListMedical().DefaultView;
        }

        public void LoadDataToDatagridDepartment()
        {
            dtgDepartment.ItemsSource = DepartmentDAL.Instance.GetListDepartment().DefaultView;
        }


        #endregion

        #region Lấy ra giá trị của Row trong bảng khi click chuột
        private void GetValueFromSelectedRowChangedMedical(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _DonViTinh = dataRow.Row.ItemArray[2].ToString();
                int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                txtTenYTe.Text = _Name;
                txtDonViTinh.Text = _DonViTinh;
                txtGia.Text = _Price.ToString();
                txtNoteYTe.Text = "";

            }
            catch { }

        }

        private void GetValueFromSelectedRowChangedDepartment(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _Note = dataRow.Row.ItemArray[2].ToString();

                txtTenBoPhan.Text = _Name;
                txtNoteBoPhan.Text = _Note;

            }
            catch { }

        }

        #endregion

    }
}
