using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using WpfAppYMPI_SPKRFID.Models;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class EmployeeFormViewModel : BindableBase
    {
        private EmployeeListModel employeeListModel;

        public EmployeeFormViewModel()
        {
            employeeListModel = EmployeeListModel.Instance;
        }

        public EmployeeListModel EmployeeListModel
        {
            get
            {
                return employeeListModel;
            }

            set
            {
                SetProperty(ref employeeListModel, value);
            }
        }
    }
}
