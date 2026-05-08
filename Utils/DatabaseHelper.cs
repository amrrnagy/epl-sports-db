using System.Configuration;
using System.Data.SqlClient;

namespace EPL_DBMS.Utils
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            // It must use "EPL" to match your app.config
            string connString = ConfigurationManager.ConnectionStrings["EPL"].ConnectionString;
            return new SqlConnection(connString);
        }
    }
}