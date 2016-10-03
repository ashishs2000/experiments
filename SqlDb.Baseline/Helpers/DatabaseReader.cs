using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SqlDb.Baseline.Helpers
{
    public static class DatabaseReader
    {
        private static readonly string Connection = ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        public static void Execute(string query, Action<SqlDataReader> extract)
        {
            using (var con = new SqlConnection(Connection))
            {
                var command = new SqlCommand(query, con);
                con.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    extract(reader);
                }
            }
        }
    }
}