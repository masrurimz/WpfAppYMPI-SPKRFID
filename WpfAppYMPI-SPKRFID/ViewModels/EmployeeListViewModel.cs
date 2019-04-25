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
using System.Data.OleDb;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class EmployeeListViewModel : BindableBase
    {
        public ICommand ShowAddEmployeeFormCommand { get; private set; }
        public ICommand ShowEditEmployeeFormCommand { get; private set; }
        public ICommand ShowDeleteEmployeeFormCommand { get; private set; }
        private EmployeeListModel employeeListModel;

        public EmployeeListViewModel()
        {
            employeeListModel = EmployeeListModel.Instance;
            ShowAddEmployeeFormCommand = new DelegateCommand(OnAddEmployeeForm);
            ShowEditEmployeeFormCommand = new DelegateCommand(OnEditEmployeeForm);
            ShowDeleteEmployeeFormCommand = new DelegateCommand(OnDeleteEmployeeForm);
        }

        private async void OnDeleteEmployeeForm()
        {
            try
            {
                FillDataField();
                var dialog = new Views.DeleteDialogConfirmView();
                object result = await MaterialDesignThemes.Wpf.DialogHost.Show(dialog, "EmployeeFormDialogHost");
                if (!(result is bool boolResult && boolResult))
                {
                    OleDbCommand dbCommand = new OleDbCommand();
                    dbCommand.Connection = EmployeeListModel.DataBaseModel.dbConnection;
                    dbCommand.CommandText = "DELETE FROM tbEmployeeList WHERE NIK='" + EmployeeListModel.Nik + "'";
                    dbCommand.ExecuteNonQuery();
                    EmployeeListModel.Refresh();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please Select one Item");
            }
        }

        private void FillDataField()
        {
            EmployeeListModel.Instance.Nik = EmployeeListModel.SelectedRow["NIK"].ToString();
            EmployeeListModel.Instance.Name = EmployeeListModel.SelectedRow["NameEmp"].ToString();
            EmployeeListModel.Instance.Occupation = EmployeeListModel.SelectedRow["Occupation"].ToString();
        }

        private void OnEditEmployeeForm()
        {
            try
            {
                EmployeeListModel.IsNikEditable = false;
                FillDataField();
                OnShowEmployeeForm();
            }
            catch(Exception)
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
