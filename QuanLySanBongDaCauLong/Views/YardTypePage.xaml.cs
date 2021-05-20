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
    /// Interaction logic for YardTypePage.xaml
    /// </summary>
    public partial class YardTypePage : Page
    {
        public YardTypePage()
        {
            InitializeComponent();
            LoadData();
        }


        #region LoadData

        public void LoadData()
        {
            LoadDataToDatagridYardTypeSoccer();
            LoadDataToDatagridYardTypeBadminton();
        }

        public void LoadDataToDatagridYardTypeSoccer()
        {
            dtgYardTypeSoccer.ItemsSource = YardTypeDAL.Instance.GetListYardTypeSoccer().DefaultView;
        }

        public void LoadDataToDatagridYardTypeBadminton()
        {
            dtgYardTypeBadminton.ItemsSource = YardTypeDAL.Instance.GetListYardTypeBadminton().DefaultView;
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

                txtTenSanBongDa.Text = _Name;
                txtDonViTinhSanBongDa.Text = _DonViTinh;
                txtGiaSanBongDa.Text = _Price.ToString();
                txtGhiChuSanBongDa.Text = "";

            }
            catch { }

        }

        private void GetValueFromSelectedRowChangedBadminton(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _GhiChu = "";
                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _DonViTinh = dataRow.Row.ItemArray[2].ToString();
                int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                txtTenSanCauLong.Text = _Name;
                txtDonViTinhSanCauLong.Text = _DonViTinh;
                txtGiaSanCauLong.Text = _Price.ToString();
                txtGhiChuSanCauLong.Text = "";

            }
            catch { }

        }

        #endregion

    }
}
