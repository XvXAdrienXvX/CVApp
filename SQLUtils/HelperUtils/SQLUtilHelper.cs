using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUtils.HelperUtils
{
    public class SQLUtilHelper
    {
        public SQLUtilHelper()
        {

        }

        public static IEnumerable<dynamic> ConvertDataTableToList(DataTable dt)
        {
            List<dynamic> dtList = new List<dynamic>();

            foreach (var row in dt.Rows)
            {
                dtList.Add(row);
            }

            return dtList.ToList();
        }
    }
}
