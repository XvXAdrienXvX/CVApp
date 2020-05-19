using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using SQLUtils.HelperUtils;

namespace CVApp
{
    public class DBConnect
    {
        private static readonly string path = ConfigurationManager.ConnectionStrings["connection"].ToString();

        public static SqlConnection CreateSQLConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();           
            
            sqlConnection.ConnectionString = path;
            return sqlConnection;
        }

        public static IEnumerable<dynamic> SelectRows(string queryString, SqlConnection connect)
        {
            var dataTableResults = new DataTable();

            using (var connection = new SqlConnection(path))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, connect);
                    adapter.Fill(dataTableResults);
                    connection.Close();

                    return SQLUtilHelper.ConvertDataTableToList(dataTableResults);
                }
                catch(Exception e)
                {
                    throw new Exception($"Unable to get data because of:{e}");
                }
            }

        }

        public static void InsertRows(string queryString, SqlConnection connect, List<SqlParameter> param)
        {
            using (var connection = new SqlConnection(path))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = queryString;
                    foreach (var SqlParam in param)
                    {
                        cmd.Parameters.Add(SqlParam);
                    }                    
                                   
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
            }
        }

    }
}