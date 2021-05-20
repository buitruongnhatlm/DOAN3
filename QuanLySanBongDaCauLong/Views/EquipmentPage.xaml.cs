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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
            LoadData();
        }

        #region LoadData

        public void LoadData()
        {
            LoadDataToDatagridSoccer();
            LoadDataToDatagridBadminton();
        }

        public void LoadDataToDatagridSoccer()
        {
            dtgEquipmentSoccer.ItemsSource = EquipmentDAL.Instance.GetListEquipmentSoccer().DefaultView;
        }

        public void LoadDataToDatagridBadminton()
        {
            dtgEquipmentBadminton.ItemsSource = EquipmentDAL.Instance.GetListEquipmentBadminton().DefaultView;
        }


        #endregion

        #region Lấy ra giá trị của Row trong bảng khi click chuột
        private void GetValueFromSelectedRowChangedSoccer(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _DonViTinh = dataRow.Row.ItemArray[2].ToString();
                int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                txtTenDoBongDa.Text = _Name;
                txtDonViBongDa.Text = _DonViTinh;
                txtGiaBongDa.Text = _Price.ToString();
                txtNoteBongDa.Text = "";

            }
            catch { }

        }

        private void GetValueFromSelectedRowChangedBadminton(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _DonViTinh = dataRow.Row.ItemArray[2].ToString();
                int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                txtTenDoCauLong.Text = _Name;
                txtDonViCauLong.Text = _DonViTinh;
                txtGiaCauLong.Text = _Price.ToString();
                txtNoteCauLong.Text = "";

            }
            catch { }

        }

        #endregion
    }

}
