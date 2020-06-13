using CVApp;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLUtils
{
    public class SQLUtils<T>: ISQLUtils<T>
    {
        private readonly SqlConnection _sql;

        public SQLUtils()
        {
            _sql = DBConnect<T>.CreateSQLConnection();
        }
       
        public IEnumerable<T> GetObject(string query, List<SqlParameter> param = null)
        {
            return DBConnect<T>.SelectRows(query, _sql);
        }

        public void Insert(string query,List<SqlParameter>param)
        {
            DBConnect<T>.InsertRows(query, _sql, param);         
        }

        public void ClearParamList (List<SqlParameter> param)
        {
            param.Clear();
        }

        public int GetObjectId(string query, List<SqlParameter> param = null)
        {
            return DBConnect<T>.GetId(query, _sql, param);
        }

        public IEnumerable<T> GetObjectWithParam(string query, List<SqlParameter> param = null)
        {
            return DBConnect<T>.SelectRows(query, _sql, param);
        }
    }
}
