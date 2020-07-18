using CVApp;
using SQLUtils.HelperUtils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLUtils
{
    public class SQLUtils: ISQLUtils
    {
        private readonly SqlConnection _sql;

        public SQLUtils()
        {
            _sql = DBConnect.CreateSQLConnection();
        }
       
        public DataTable GetObject(string query, List<SqlParameter> param = null)
        {
            return DBConnect.SelectRows(query, _sql);
        }

        public void Insert(string query,List<SqlParameter>param)
        {
            DBConnect.InsertRows(query, _sql, param);         
        }

        public void ClearParamList (List<SqlParameter> param)
        {
            param.Clear();
        }

        public int GetObjectId(string query, List<SqlParameter> param = null)
        {
            return DBConnect.GetId(query, _sql, param);
        }

        public DataTable GetObjectWithParam(string query, List<SqlParameter> param = null)
        {
            return DBConnect.SelectRows(query, _sql, param);
        }
    }
}
