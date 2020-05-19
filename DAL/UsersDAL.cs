using DAL.Interface;
using SQLUtils;
using System.Collections.Generic;

namespace DAL
{
    public class UsersDAL : IUsersDAL
    {

        private readonly ISQLUtils _sqlutil;

        public UsersDAL(ISQLUtils sqlutil)
        {
            _sqlutil = sqlutil;
        }

        public IEnumerable<dynamic> GetUsers()
        {
            string query = "SELECT * FROM Users";

            return _sqlutil.GetObject(query);
        }

        public IEnumerable<dynamic> GetUserDetails()
        {
            string query = "SELECT * FROM UserInfo P LEFT JOIN Skills S ON P.User_ID=S.User_ID";

            return _sqlutil.GetObject(query);
        }

    }
}
