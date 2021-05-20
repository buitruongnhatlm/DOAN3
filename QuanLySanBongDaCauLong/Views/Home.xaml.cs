using QuanLySanBongDaCauLong.Views;
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
using System.Windows.Shapes;

namespace QuanLySanBongDaCauLong
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int _indexButtonSelected = int.Parse(((Button)e.Source).Uid);

            ChangeCursor(_indexButtonSelected);

            switch (_indexButtonSelected)
            {
                case 0:
                    FrameMain.Content = new SoccerPage();
                    break;

                case 1:
                    FrameMain.Content = new BadmintonPage();
                    break;

                case 2:
                    FrameMain.Content = new FoodPage();
                    break;

                case 3:
                    FrameMain.Content = new YardTypePage();
                    break;

                case 4:
                    FrameMain.Content = new EquipmentPage();
                    break;

                case 6:
                    FrameMain.Content = new BillPage();
                    break;

                case 5:
                    FrameMain.Content = new MedicalPage();
                    break;

                case 7:
                    FrameMain.Content = new ManagerPage();
                    break;

                case 8:
                    FrameMain.Content = new AccountPage();
                    break;

            }
        }

        private void ChangeCursor(int index)
        {
            switch (index)
            {
                case 0:
                    Cursor.Margin = new Thickness(-675,5,-40,35);
                    break;
                case 1:
                    Cursor.Margin = new Thickness(-525, 5, -10, 35);
                    break;
                case 2:
                    Cursor.Margin = new Thickness(-375, 5, -30, 35);
                    break;
                case 3:
                    Cursor.Margin = new Thickness(-225, 5, -50, 35);
                    break;
                case 4:
                    Cursor.Margin = new Thickness(-75, 5, -30, 35);
                    break;
                case 5:
                    Cursor.Margin = new Thickness(75, 5, -40, 35);
                    break;
                case 6:
                    Cursor.Margin = new Thickness(225, 5, -40, 35);
                    break;
                case 7:
                    Cursor.Margin = new Thickness(375, 5, -30, 35);
                    break;
                case 8:
                    Cursor.Margin = new Thickness(525, 5, -20, 35);
                    break;
                case 9:
                    Cursor.Margin = new Thickness(675, 5, -30, 35);
                    break;

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Uri _uri =  new Uri ("/Images/hinhnenbongda.jpg",UriKind.Relative);
            Image _img = new Image();
            _img.Source = new BitmapImage(_uri);
            _img.Stretch = Stretch.Fill;
            _img.Width = 800;
            _img.Height = 450;
            FrameMain.Content = _img;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
