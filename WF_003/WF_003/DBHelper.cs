using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_003
{
    class DBHelper
    {
        private static string connectionString = @"Data Source=HOVANVYDUT;Initial Catalog=StudentManagement;Integrated Security=True";
        private SqlConnection cnn;
        private DBHelper _Instance;
        public DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper(connectionString); 
                }

                return _Instance;
            }

            set
            {

            }
        }

        private DBHelper(string connectionString)
        {
            this.cnn = new SqlConnection(connectionString);
        }

        public DataTable GetRecords(string query)
        {
            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand(query, cnn);


        }
    }
}
