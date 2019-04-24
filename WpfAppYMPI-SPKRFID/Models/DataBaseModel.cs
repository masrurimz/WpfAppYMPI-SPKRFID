using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Prism.Mvvm;


namespace WpfAppYMPI_SPKRFID.Models
{
    class DataBaseModel : BindableBase
    {
        public OleDbConnection dbConnection = new OleDbConnection
        {
            ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\AppDB.mdb"
        };

        public DataBaseModel()
        {
            
        }
    }
}
