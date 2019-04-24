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
using WpfAppYMPI_SPKRFID.ViewModels;

namespace WpfAppYMPI_SPKRFID.Views
{
    /// <summary>
    /// Interaction logic for EmployeeFormView.xaml
    /// </summary>
    public partial class EmployeeFormView : UserControl
    {
        public EmployeeFormView()
        {
            InitializeComponent();
            this.DataContext = new EmployeeFormViewModel();
        }
    }
}
