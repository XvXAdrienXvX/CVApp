using CVApp;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLUtils
{
    public class SQLUtils : ISQLUtils
    {
        private readonly SqlConnection _sql;

        public SQLUtils()
        {
            _sql = DBConnect.CreateSQLConnection();
        }
       
        public IEnumerable<dynamic> GetObject(string query, List<SqlParameter> param = null)
        {
            return DBConnect.SelectRows(query, _sql);
        }

        public void Insert(string query,List<SqlParameter>param)
        {
            DBConnect.InsertRows(query, _sql, param);         
        }

    }
}
