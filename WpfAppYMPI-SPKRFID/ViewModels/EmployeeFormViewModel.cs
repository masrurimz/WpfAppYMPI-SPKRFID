using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Data.OleDb;
using WpfAppYMPI_SPKRFID.Models;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class EmployeeFormViewModel : BindableBase
    {
        private EmployeeListModel employeeListModel;
        public ICommand SaveEmployeeFormCommand { get; private set; }

        public EmployeeFormViewModel()
        {
            employeeListModel = EmployeeListModel.Instance;
            SaveEmployeeFormCommand = new DelegateCommand(OnSaveEmployeeForm);
        }

        private void OnSaveEmployeeForm()
        {
            OleDbCommand dbCommand = new OleDbCommand();
            dbCommand.Connection = EmployeeListModel.DataBaseModel.dbConnection;
            if (EmployeeListModel.Nik != "")
            {
                if (EmployeeListModel.IsNikEditable == true)
                {
                    dbCommand.CommandText = "INSERT INTO tbEmployeeList (NIK,NameEmp,Occupation) VALUES ('" + EmployeeListModel.Nik + "','" + EmployeeListModel.Name + "','" + EmployeeListModel.Occupation + "')";
                    dbCommand.ExecuteNonQuery();
                }
                else
                {
                    dbCommand.CommandText = "UPDATE tbEmployeeList SET NameEmp = '" + EmployeeListModel.Name + "', Occupation = '" + EmployeeListModel.Occupation + "' WHERE NIK = '" + EmployeeListModel.Nik + "'";
                    dbCommand.ExecuteNonQuery();
                }
                EmployeeListModel.Refresh();
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);
            }
            else
            {
                System.Windows.MessageBox.Show("Please add NIK");
            }
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
