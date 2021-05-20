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
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public FoodPage()
        {
            InitializeComponent();
            LoadData();
        }

        #region LoadData

        public void LoadData()
        {
            LoadDataToDatagridFood();
        }

        public void LoadDataToDatagridFood()
        {
            dtgFood.ItemsSource = FoodDAL.Instance.GetListFood().DefaultView;
        }

        #endregion

        #region Lấy ra giá trị của Row trong bảng khi click chuột
        private void GetValueFromSelectedRowChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;

                string _Name = dataRow.Row.ItemArray[1].ToString();
                string _DonViTinh = dataRow.Row.ItemArray[2].ToString();
                int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                txtTenDoUong.Text = _Name;
                txtDonViTinh.Text = _DonViTinh;
                txtGia.Text = _Price.ToString();
                txtGhiChu.Text = "";

            }
            catch { }

        }

        #endregion

    }
}
