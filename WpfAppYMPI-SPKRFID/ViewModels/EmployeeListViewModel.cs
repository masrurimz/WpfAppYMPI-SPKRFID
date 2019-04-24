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
        public ICommand ShowAddEmployeeFormCommand { get; private set; }
        public ICommand ShowEditEmployeeFormCommand { get; private set; }
        private EmployeeListModel employeeListModel;

        public EmployeeListViewModel()
        {
            employeeListModel = EmployeeListModel.Instance;
            ShowAddEmployeeFormCommand = new DelegateCommand(OnAddEmployeeForm);
            ShowEditEmployeeFormCommand = new DelegateCommand(OnEditEmployeeForm);
        }

        private void OnEditEmployeeForm()
        {
            try
            {
                EmployeeListModel.IsNikEditable = false;
                EmployeeListModel.Instance.Nik = EmployeeListModel.SelectedRow["NIK"].ToString();
                EmployeeListModel.Instance.Name = EmployeeListModel.SelectedRow["Nama"].ToString();
                EmployeeListModel.Instance.Occupation = EmployeeListModel.SelectedRow["Jabatan"].ToString();
                OnShowEmployeeForm();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Please Select one Item");
            }
        }

        private void OnAddEmployeeForm()
        {
            EmployeeListModel.IsNikEditable = true;
            OnShowEmployeeForm();
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
