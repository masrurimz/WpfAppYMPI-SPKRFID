using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using WpfAppYMPI_SPKRFID.Models;
using MaterialDesignThemes.Wpf;
using System.Data;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class EmployeeListViewModel : BindableBase
    {
        public ICommand ShowEmployeeFormCommand { get; private set; }
        public ICommand ShowEditEmployeeFormCommand { get; private set; }
        private EmployeeListModel employeeListModel;

        public EmployeeListViewModel()
        {
            employeeListModel = EmployeeListModel.Instance;
            ShowEmployeeFormCommand = new DelegateCommand(OnShowEmployeeForm);
            ShowEditEmployeeFormCommand = new DelegateCommand(OnEditEmployeeForm);
        }

        private async void OnEditEmployeeForm()
        {
            if (EmployeeListModel.SelectedRow != null)
            {
                EmployeeListModel.Nik = EmployeeListModel.SelectedRow["NIK"].ToString();
                EmployeeListModel.Name = EmployeeListModel.SelectedRow["Nama"].ToString();
                EmployeeListModel.Occupation = EmployeeListModel.SelectedRow["Jabatan"].ToString();
                OnShowEmployeeForm();
            }
            else
                System.Windows.MessageBox.Show("Please Select one Item");
        }

        private void ClearAll()
        {
            EmployeeListModel.Nik = "";
            EmployeeListModel.Name = "";
            EmployeeListModel.Occupation = "";
        }

        private async void OnShowEmployeeForm()
        {
            var dialog = new Views.EmployeeFormView();
            await MaterialDesignThemes.Wpf.DialogHost.Show(dialog, "EmployeeFormDialogHost");
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
