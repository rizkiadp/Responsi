using System;
using System.Data.SqlClient;

namespace Pemrog.Setup
{
    public class Db_Connection
    {
        public SqlConnection SqlConnection;
        public string SqlNotice;

        public Db_Connection()
        {
            SqlConnection = new SqlConnection();
            dbserver = @"DESKTOP-JILUIVT";
            dbname = "retailer_DB";
        }

        public bool OpenConnection()
        {
            SqlConnection.ConnectionString =
                $"Server={dbserver};Database={dbname};Trusted_Connection=yes;";
            SqlConnection.InfoMessage += Notice_Handler;
            SqlConnection.FireInfoMessageEventOnUserErrors = true;
            SqlConnection.Open();
            return true;
        }

        private readonly string dbserver;
        private readonly string dbname;

        private void Notice_Handler(object sender, SqlInfoMessageEventArgs e)
        {
            SqlNotice = e.Message;
        }

        internal void CloseConnection()
        {
     
        }
    }
}
