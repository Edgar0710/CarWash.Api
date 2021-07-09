using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarWash.Data
{
    public class DataRepository : IDisposable
    {
        protected IDbConnection conn;

        public DataRepository()
        {
            string strConnection = @"Server=3.140.176.65;Port=3309;Database=dcarwash;Uid=admin;Pwd=IGDS_2021;";
            conn = new MySqlConnection(strConnection);
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
