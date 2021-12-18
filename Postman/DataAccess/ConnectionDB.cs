using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Dapper;

namespace Postman.DataAccess
{
    public class  ConnectionDB
    {

        private static readonly string dbstring = ConfigurationManager.ConnectionStrings["dbstring"].ConnectionString;
        private static readonly IDbConnection sqlcon = new SqlConnection(dbstring);

        public static List<T> SelectQuery<T>(string query, object p = null)
        {
            var result = sqlcon.Query<T>(query, p).ToList();
            return result;
        }

        public static int ExecuteQuery(string sql, object p = null)
        {
            var affectedRows = sqlcon.Execute(sql, p);
            return affectedRows;

        }

        public static IDbConnection getConnection()
        {
            return sqlcon;
        }
    }
}
