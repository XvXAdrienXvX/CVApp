using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLUtils
{
    public interface ISQLUtils
    {
        IEnumerable<dynamic> GetObject(string query, List<SqlParameter> param = null);

        void Insert(string query,List<SqlParameter>param);
    }
}
