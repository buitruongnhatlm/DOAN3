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
            }
        }

        private void ChangeCursor(int index)
        {
            switch (index)
            {
                case 0:
                    Cursor.Margin = new Thickness(-525,5,-40,35);
                    break;
                case 1:
                    Cursor.Margin = new Thickness(-375, 5, -10, 35);
                    break;
                case 2:
                    Cursor.Margin = new Thickness(-225, 5, -30, 35);
                    break;
                case 3:
                    Cursor.Margin = new Thickness(-75, 5, -50, 35);
                    break;
                case 4:
                    Cursor.Margin = new Thickness(75, 5, -30, 35);
                    break;
                case 5:
                    Cursor.Margin = new Thickness(225, 5, -40, 35);
                    break;
                case 6:
                    Cursor.Margin = new Thickness(375, 5, -20, 35);
                    break;
                case 7:
                    Cursor.Margin = new Thickness(525, 5, -30, 35);
                    break;

            }
        }


    }
}
