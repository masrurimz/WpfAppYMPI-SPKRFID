using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Data.OleDb;
using System.Data;

namespace WpfAppYMPI_SPKRFID.Models
{
    class SPKModel : BindableBase
    {
        private static readonly SPKModel _instance = new SPKModel();
        private static SPKModel Instance { get { return _instance; } }
        private SPKModel sPKModel = SPKModel.Instance;
        public SPKModel()
        {
            
        }

        private OleDbCommand dbCommand = new OleDbCommand();
        private DataTable dataTable = new DataTable();
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
        private OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter();

        public void Refresh()
        {

        }

        private DataBaseModel dataBaseModel = DataBaseModel.Instance;
        public DataBaseModel DataBaseModel
        {
            get { return dataBaseModel; }
            set { SetProperty(ref dataBaseModel, value); }
        }
    }
}
