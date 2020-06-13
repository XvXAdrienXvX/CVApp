using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUtils.HelperUtils
{
    public class SQLUtilHelper<T>
    {
        public SQLUtilHelper()
        {

        }

        public static IEnumerable<T> ConvertDataTableToList(DataTable dt)
        {
            List<T> dtList = new List<T>();

            foreach (T row in dt.Rows)
            {
                dtList.Add(row);
            }

            return dtList.ToList();
        }
    }
}
