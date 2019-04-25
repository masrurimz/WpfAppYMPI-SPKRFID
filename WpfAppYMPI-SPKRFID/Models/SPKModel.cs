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
        public static SPKModel Instance { get { return _instance; } }
        private SPKModel sPKModel = SPKModel.Instance;
        public SPKModel()
        {
            if (DataBaseModel.dbConnection.State != ConnectionState.Open)
                DataBaseModel.dbConnection.Open();
        }

        private OleDbCommand dbCommand = new OleDbCommand();
        private AppDbDataSet dataSet = new AppDbDataSet();
        private AppDbDataSetTableAdapters.qrSPKJobLogTableAdapter dataTableAdapter = new AppDbDataSetTableAdapters.qrSPKJobLogTableAdapter();
        public AppDbDataSet SPKDataTable
        {
            get
            {
                Refresh();
                return dataSet;
            }

            set
            {
                SetProperty(ref dataSet, value);
            }
        }

        public void Refresh()
        {
            dataTableAdapter.Fill(dataSet.qrSPKJobLog);
        }

        private DataBaseModel dataBaseModel = DataBaseModel.Instance;
        public DataBaseModel DataBaseModel
        {
            get { return dataBaseModel; }
            set { SetProperty(ref dataBaseModel, value); }
        }
    }
}
