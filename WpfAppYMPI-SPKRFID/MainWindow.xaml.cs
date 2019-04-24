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
using WpfAppYMPI_SPKRFID;


namespace WpfAppYMPI_SPKRFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string IsLoading;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                //case "ItemHome":
                //    usc = new UserControlHome();
                //    GridMain.Children.Add(usc);
                //    break;
                case "ItemSPK":
                    usc = new UserControlSPK();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemPM":
                    usc = new Views.PMView();
                    GridMain.Children.Add(usc);
                    break;
                //case "ItemProject":
                //    usc = new UserControlProject();
                //    GridMain.Children.Add(usc);
                //    break;
                case "ItemSettings":
                    usc = new UserControlEmployee();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemEmployeeList":
                    usc = new Views.EmployeeListView();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaxiMiniMize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
