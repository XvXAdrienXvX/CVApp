using DAL.Interface;
using SQLUtils;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class UsersDAL: IUsersDAL
    {

        private readonly ISQLUtils _sqlutil;
        private List<SqlParameter> _param;

        public UsersDAL(ISQLUtils sqlutil)
        {
            _sqlutil = sqlutil;
            _param = new List<SqlParameter>();
        }

        public IEnumerable<dynamic> GetUsers()
        {
            const string query = @"SELECT * FROM Users";

            return _sqlutil.GetObject(query);
        }

        public IEnumerable<dynamic> GetUserDetails()
        {
            const string query = @"SELECT UD.FirstName, UD.Phone, UD.Email, UD.Resume 
                                   FROM UserDetails AS UD LEFT JOIN UserSkills AS US ON UD.UserId=US.UserId";

            return _sqlutil.GetObject(query);
        }

        public IEnumerable<dynamic> GetUserById(int UserId)
        {
            const string query = @"SELECT U.UserID, U.Username, UD.FirstName, UD.Phone, UD.Email, UD.Resume,
                                   CAST(CASE WHEN EXISTS(SELECT 1 FROM AppAdmin AS AA WHERE AA.UserId = U.UserID)
                                   THEN 'True' ELSE 'False' END AS BIT) AS Admin
                                   FROM Users AS U
                                   JOIN UserDetails AS UD ON U.UserID = UD.UserId
                                   WHERE U.UserID = @UserID";

            _sqlutil.ClearParamList(_param);

            _param = new List<SqlParameter>
            {
                new SqlParameter("UserID",UserId),
            };

            return _sqlutil.GetObjectWithParam(query, _param);
        }

        public int GetUserId(string username, string password)
        {
            const string query = "SELECT UserID FROM Users WHERE Username = @username AND Password = @password";

            _param = new List<SqlParameter>
            {
                new SqlParameter("username",username),
                new SqlParameter("password",password)
            };

            return _sqlutil.GetObjectId(query, _param);
        }
    }
}
