using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    
    public static class ConnectionManager
    {
        private static string ConnectionString { get; set; }
        private static void InitConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "SQL5074.site4now.net";
            builder.InitialCatalog = "DB_A72A98_RecipeAndRoll";
            builder.IntegratedSecurity = false; // win auth
            builder.UserID = "DB_A72A98_RecipeAndRoll_admin";
            builder.Password = "recipesDBm42";
            ConnectionString = builder.ConnectionString;
        }
        public static SqlConnection CreateConnection()
        {
            if (string.IsNullOrEmpty(ConnectionString))  // mi hat  ! ka te che?
            {
                InitConnectionString();
            }
            return new SqlConnection(ConnectionString);
        }
       
    }
}
