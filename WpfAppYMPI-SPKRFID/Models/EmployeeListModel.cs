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
        private DataBaseModel dataBaseModel = DataBaseModel.Instance;
        public DataBaseModel DataBaseModel
        {
            get
            {
                return dataBaseModel;
            }

            set
            {
                SetProperty(ref dataBaseModel, value);
            }
        }

        private OleDbCommand dbCommand = new OleDbCommand();
        private DataTable dataTable = new DataTable();
        private OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter();

        private string _name;
        private string _nik;
        private string _occupation;
        private string _status;

        private bool _isNikEditable;
        public bool IsNikEditable
        {
            get
            {
                return _isNikEditable;
            }
            set
            {
                SetProperty(ref _isNikEditable, value);
            }
        }

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

        private static readonly EmployeeListModel _instance = new EmployeeListModel();
        public static EmployeeListModel Instance { get { return _instance; } }

        public EmployeeListModel()
        {
            if (DataBaseModel.dbConnection.State != ConnectionState.Open)
                DataBaseModel.dbConnection.Open();
        }

        public void Refresh()
        {
            dbCommand.Connection = DataBaseModel.dbConnection;
            dbCommand.CommandText = "select * from EmployeeList";
            dbDataAdapter.SelectCommand = dbCommand;
            dataTable.Clear();
            dbDataAdapter.Fill(dataTable);
        }


        public DataTable EmployeeDataTable
        {
            get
            {
                Refresh();
                return dataTable;
            }

            set
            {
                SetProperty(ref dataTable, value);
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
