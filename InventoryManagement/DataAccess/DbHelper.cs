using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement.DataAccess
{
    public static class DbHelper
    {
        private static readonly string _connection = ConfigurationManager.ConnectionStrings["InventoryManagementDb"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connection);
        }
    }
}