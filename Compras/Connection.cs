using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Compras
{
    public class Connection
    {
        public static string ConnectionString { get; set; }
        public SqlConnection cnn{ get; set; }

        public SqlConnection connect_to_database ()
        {
            cnn = new SqlConnection(ConnectionString);
            return cnn;
        }
    }
}
