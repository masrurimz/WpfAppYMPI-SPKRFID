using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Controls;
using WpfAppYMPI_SPKRFID.Models;
using Prism.Mvvm;

namespace WpfAppYMPI_SPKRFID.Models
{
    class EmployeeListModel : BindableBase
    {
        private DataBaseModel dataBaseModel;
        private OleDbCommand dbCommand = new OleDbCommand();
        private DataTable dataTable = new DataTable();

        private string _name = "karibou";
        private string _nik;
        private string _occupation;
        private string _status;

        private DataRowView _selectedRow;
        public DataRowView SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                SetProperty(ref _selectedRow, value);
            }
        }

        private static EmployeeListModel _instance = new EmployeeListModel();
        public static EmployeeListModel Instance { get { return _instance; } }

        public EmployeeListModel()
        {
            dataBaseModel = new DataBaseModel();
            if (dataBaseModel.dbConnection.State != ConnectionState.Open)
                dataBaseModel.dbConnection.Open();
        }

        public DataTable EmployeeDataTable
        {
            get

            {
                dbCommand.Connection = dataBaseModel.dbConnection;
                dbCommand.CommandText = "select * from EmployeeList";
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(dbCommand);
                dbDataAdapter.Fill(dataTable);
                return dataTable;
            }

            set
            {

            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string Nik
        {
            get
            {
                return _nik;
            }
            set
            {
                SetProperty(ref _nik, value);
            }
        }

        public string Occupation
        {
            get
            {
                return _occupation;
            }
            set
            {
                SetProperty(ref _occupation, value);
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                SetProperty(ref _status, value);
            }
        }
    }
}
