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
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using QuanLySanBongDaCauLong.Views;

namespace QuanLySanBongDaCauLong
{

    public partial class SoccerPage : Page
    {

        public SoccerPage()
        {
            InitializeComponent();
            LoadData();
        }

        #region Global Variable

        // Biến toàn cục lưu số thứ tự bảng hóa đơn
        int _SoThuTuTemp = 1;

        // Biến toàn cục lưu tổng giá tiền tạm thời
        int _TongGiaTemp = 0;

        // Biến và propeties giá trị numeric updown
        private int _numValue = 1;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNumeric.Text = value.ToString();
            }
        }

        #endregion

        #region Methods

        #region LoadData

        public void LoadData()
        {
            LoadDataToDatagridFood();
            LoadDataToDatagridMedical();
            LoadDataToDatagridYardType();
            LoadDataToDatagridEquipment();
            txtNumeric.Text = _numValue.ToString(); // khởi tạo giá trị mặc định của cho numeric bằng biến toàn cục (1)
        }

        public void LoadDataToDatagridFood()
        {
            dtgFood.ItemsSource = FoodDAL.Instance.GetListFood().DefaultView;
        }

        public void LoadDataToDatagridMedical()
        {
            dtgMedical.ItemsSource = MedicalDAL.Instance.GetListMedical().DefaultView;
        }

        public void LoadDataToDatagridYardType()
        {
            dtgYardType.ItemsSource = YardTypeDAL.Instance.GetListYardTypeSoccer().DefaultView;
        }

        public void LoadDataToDatagridEquipment()
        {
            dtgEquipment.ItemsSource = EquipmentDAL.Instance.GetListEquipmentSoccer().DefaultView;
        }

        #endregion

        #region Refesh Controls

        public void RefeshControls()
        {
            txtTongThu.Text = txtHoanLai.Text = "0";
            txtTongCong.Text=txtGiamGia.Text=txtTongTien.Text="0";
            txtTenKhachHang.Text = txtLoai.Text = txtGia.Text = txtMatHang.Text = "";
            dtgMain.Items.Clear();
            dtgYardType.IsEnabled = true;

        }

        #endregion

        #region Lấy ra giá trị của Row trong bảng khi click chuột
        private void GetValueFromSelectedRowChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if ((sender as DataGrid).Name != string.Format("dtgMain"))
                {
                    DataRowView dataRow = (DataRowView)(sender as DataGrid).SelectedItem;
                    // int _ID = Convert.ToInt32(dataRow.Row.ItemArray[0]);
                    string _Name = dataRow.Row.ItemArray[1].ToString();
                    int _Price = Convert.ToInt32(dataRow.Row.ItemArray[4]);

                    txtLoai.Text = dataRow.Row.ItemArray[3].ToString();
                    txtMatHang.Text = _Name;
                    txtGia.Text = _Price.ToString();
                }
                else
                {
                    if (CollectionViewSource.GetDefaultView(dtgMain.SelectedItem) == null) // trả các giá trị về null sau khi xóa item
                    {
                        txtMatHang.Text = "";
                        txtGia.Text = "0";
                        txtLoai.Text = "";
                        ResetValueNumeric();
                    }
                    else // gán giá trị cho các controls khi click chuột vào dtgMain
                    {
                        ICollectionView view = CollectionViewSource.GetDefaultView(dtgMain.SelectedItem);
                        var item = (ListData)view.CurrentItem;
                        txtMatHang.Text = item.MatHang;
                        txtLoai.Text = item.Loai;
                        txtGia.Text = item.Gia.ToString();
                        txtNumeric.Text = item.SoLuong.ToString();
                    }
                }
            }
            catch { }
            
        }
        #endregion

        #region Numeric Updown

        private void numericUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
            if (NumValue > 99)
            {
                NumValue = 99;
            }
        }

        private void numericDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
            if (NumValue <= 0)
            {
                NumValue = 1;
            }
        }

        public void ResetValueNumeric()
        {
            NumValue = 1;
        }

        #endregion

        private void AddBill(string customername, int price, int discount, int totalprice,int proceeds, int change)
        {
            if (BillDAL.Instance.InsertBill(customername, price, discount, totalprice, proceeds, change))
            {
                CustomMessageBox.Show("Thông Báo", "Tạo Bill Thành Công", MessageBoxButton.OK);
            }

            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

            //LoadData();
        }

        private void AddBillInfomation(int idbill, int idfood, int foodcount, int idmedical, int medicalcount, int idequipment, int equipmentcount, int idyardtype, int yardtypecount, int idmanager)
        {
            if (BillInfomationDAL.Instance.InsertBillInfomation(idbill, idfood, foodcount, idmedical, medicalcount, idequipment, equipmentcount, idyardtype, yardtypecount, idmanager))
            {
                CustomMessageBox.Show("Thông Báo", "Tạo Thông Tin Hóa Đơn Thành Công", MessageBoxButton.OK);
            }

            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

            //LoadData();
        }

        #endregion

        #region Events

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<ListData> _list = new List<ListData>();
            List<ListData> _result = new List<ListData>();

            // kiểm tra null mặt hàng và giá trước khi thêm
            if (!string.IsNullOrEmpty(txtMatHang.Text) && !string.IsNullOrEmpty(txtGia.Text))
            {
                if (dtgMain.Items.Count == 0)
                {
                    _TongGiaTemp = 0;
                }

                _list.Add(new ListData() { So = _SoThuTuTemp, MatHang = txtMatHang.Text, SoLuong = _numValue, Gia = Convert.ToInt32(txtGia.Text), Tien = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(txtNumeric.Text), Loai = txtLoai.Text });
                _result = _list;
                _SoThuTuTemp++; // sau khi thêm sp sẽ tăng stt lên 1
                dtgMain.Items.Add(_result);

                if (_result != null)
                {
                    foreach (ListData item in _result) // sau khi thêm sân vô hiệu hóa bảng sân
                    {
                        _TongGiaTemp += item.Tien;
                        if (item.Loai.Contains("Sân"))
                        {
                            dtgYardType.IsEnabled = false;
                        }
                    }
                }

                // cập nhật tổng cộng và tổng tiền mỗi lần thêm sản phẩm
                txtTongCong.Text = _TongGiaTemp.ToString();
                txtTongTien.Text = (Convert.ToInt32(_TongGiaTemp * Convert.ToInt32(txtGiamGia.Text) / 100)).ToString();
            }

            ResetValueNumeric();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // xóa sản phẩm
            var item = dtgMain.SelectedItem;
            if (item != null)
            {
                dtgMain.Items.Remove(item);

                // mở vô hiệu hóa bảng sân khi xóa sân
                ICollectionView view = CollectionViewSource.GetDefaultView(item);
                var _tempItem = (ListData)view.CurrentItem;

                if (_tempItem.MatHang.Contains("Sân"))
                {
                    dtgYardType.IsEnabled = true;
                }

                int _result = Convert.ToInt32(txtTongCong.Text) - _tempItem.Tien;
                _TongGiaTemp = _result;
                txtTongCong.Text = _result.ToString();

                if (dtgMain.Items.Count == 0)
                {
                    _TongGiaTemp = 0;
                }

            }

        }

        private void btnKetXuat_Click(object sender, RoutedEventArgs e)
        {
            string _patternTongThu = @"^[1-9]+[0-9]*$";
            string _patternGiamGia = @"^\d(\d)?$";
            Regex _rxTongThu = new Regex(_patternTongThu);
            Regex _rxGiamGia = new Regex(_patternGiamGia);
            double _TienGiamGia;

            // kiểm tra tên khách hàng trước khi kết xuất
            if (string.IsNullOrEmpty(txtTenKhachHang.Text)) 
            {
                CustomMessageBox.Show("Thông báo", "Bạn hãy nhập tên khách hàng để kết xuất", MessageBoxButton.OK);
            }
            else
            {
                // tính tổng tiền
                if (_rxGiamGia.IsMatch(txtGiamGia.Text))
                {
                    _TienGiamGia = (Convert.ToDouble(txtTongCong.Text) * Convert.ToDouble(txtGiamGia.Text) / 100);

                    if (_TienGiamGia > 0)
                    {
                        txtTongTien.Text = (Convert.ToDouble(txtTongCong.Text) - _TienGiamGia).ToString();
                    }
                    else if (_TienGiamGia == 0)
                    {
                        txtTongTien.Text = txtTongCong.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Giảm giá không hợp lệ");
                    return;
                }

                // tính hoàn lại
                if (_rxTongThu.IsMatch(txtTongThu.Text))
                {
                    if (Convert.ToDouble(txtTongThu.Text) >= Convert.ToDouble(txtTongTien.Text))
                    {
                        txtHoanLai.Text = (Convert.ToDouble(txtTongThu.Text) - Convert.ToDouble(txtTongTien.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Tổng thu phải lớn hơn hoặc bằng tổng tiền và không được nhỏ hơn 0");
                    }
                }
                else
                {
                    MessageBox.Show("Tổng thu không hợp lệ");
                }
            }
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            var _messageBoxResult = CustomMessageBox.Show("Thông báo", "Bạn có muốn in hóa đơn không? ", MessageBoxButton.YesNoCancel);
            if (_messageBoxResult == MessageBoxResult.No)
            {
                string customerName_ = txtTenKhachHang.Text;
                int price_ = Convert.ToInt32(txtTongCong.Text);
                int discount_ = Convert.ToInt32(txtGiamGia.Text);
                int totalprice_ = Convert.ToInt32(txtTongTien.Text);
                int proceeds_ = Convert.ToInt32(txtTongThu.Text);
                int change_ = Convert.ToInt32(txtHoanLai.Text);

                int _flagCount = 0;
                bool _foodflag = true, _yardflag = true, _medicalflag = true, _equipmentflag = true;
                int _food = 1, _yard = 1, _medical = 1, _equipment = 1;
                int _foodCount = 0, _medicalCount = 0, _yardCount = 0, _equipmentCount = 0;

                for (int i = 1; i <= dtgMain.Items.Count; i++)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(dtgMain.Items[i - 1]);
                    var item = (ListData)view.CurrentItem;

                    if (item.Loai == "Thức Ăn" && _foodflag == true)
                    {
                        _food = FoodDAL.Instance.GetIDFoodByName(item.MatHang);
                        _foodCount = item.SoLuong;
                        _flagCount++;
                        _foodflag = false;
                    }
                    if (item.Loai == "Đồ" && _equipmentflag == true)
                    {
                        _equipment = EquipmentDAL.Instance.GetIDEquipmentByName(item.MatHang);
                        _equipmentCount = item.SoLuong;
                        _flagCount++;
                        _equipmentflag = false;
                    }
                    if (item.Loai == "Thuốc" && _medicalflag == true)
                    {
                        _medical = MedicalDAL.Instance.GetIDMedicalByName(item.MatHang);
                        _medicalCount = item.SoLuong;
                        _flagCount++;
                        _medicalflag = false;
                    }
                    if (item.Loai == "Sân" && _yardflag == true)
                    {
                        _yard = YardTypeDAL.Instance.GetIDYardTypeByName(item.MatHang);
                        _yardCount = item.SoLuong;
                        _flagCount++;
                        _yardflag = false;
                    }

                    if (_flagCount == 4 || i == dtgMain.Items.Count)
                    {
                        int _idBill = BillDAL.Instance.GetBillUncheck();
                        if (_idBill == -1)
                        {
                            AddBill(customerName_, price_, discount_, totalprice_, proceeds_, change_);
                            AddBillInfomation(BillDAL.Instance.GetMaxIDBill(), _food, _foodCount, _medical, _medicalCount, _equipment, _equipmentCount, _yard, _yardCount, 1);
                        }
                        else
                        {
                            AddBillInfomation(BillDAL.Instance.GetMaxIDBill(), _food, _foodCount, _medical, _medicalCount, _equipment, _equipmentCount, _yard, _yardCount, 1);
                        }

                        _foodflag = true;
                        _medicalflag = true;
                        _equipmentflag = true;
                        _yardflag = true;
                        _flagCount = 0;
                        _food = 1; _yard = 1; _medical = 1; _equipment = 1;
                        _foodCount = 0; _medicalCount = 0; _yardCount = 0; _equipmentCount = 0;
                    }
                }

                CheckoutBill(BillDAL.Instance.GetMaxIDBill());
               
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            RefeshControls();
            LoadData();
        }

        public void CheckoutBill(int idbill)
        {
            if (BillDAL.Instance.CheckoutBill(idbill))
            {
                CustomMessageBox.Show("Thông Báo", "Thanh Toán thành công", MessageBoxButton.OK);
            }

            else
            {
                CustomMessageBox.Show("Thông Báo", "Đã xảy ra lỗi! Vui lòng kiểm tra lại", MessageBoxButton.OK);
            }

        }

        #endregion

    }

    public class ListData
    {
        public int So { get; set; }
        public string MatHang { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public int Tien { get; set; }
        public string Loai { get; set; }

    }

}

    

