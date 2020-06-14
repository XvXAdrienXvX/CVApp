using DAL.Entities;
using DAL.HelperUtils;
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

        public IEnumerable<Users> GetUsers()
        {
            const string query = @"SELECT * FROM Users";

            return EntityHelper.ConvertDataTable<Users>(_sqlutil.GetObject(query));
        }

        public IEnumerable<UserDetails> GetUserDetails()
        {
            const string query = @"SELECT UD.FirstName, UD.Phone, UD.Email, UD.Resume 
                                   FROM UserDetails AS UD LEFT JOIN UserSkills AS US ON UD.UserId=US.UserId";

            return EntityHelper.ConvertDataTable<UserDetails>(_sqlutil.GetObject(query));
        }

        public IEnumerable<UserDetails> GetUserById(int UserId)
        {
            const string query = @"SELECT U.UserID, U.Username, UD.FirstName, UD.Phone, UD.Email, UD.Resume,
                                   CAST(CASE WHEN EXISTS(SELECT 1 FROM AppAdmin AS AA WHERE AA.UserId = U.UserID)
                                   THEN 'True' ELSE 'False' END AS BIT) AS Admin, US.ShortName, US.SkillLevel, US.UserSkillId
                                   FROM Users AS U
                                   JOIN UserDetails AS UD ON U.UserID = UD.UserId
                                   JOIN UserSkills AS US on U.UserID = US.UserId
                                   WHERE U.UserID = @UserID";

            _param = new List<SqlParameter>
            {
                new SqlParameter("UserID",UserId)
            };

            return EntityHelper.ConvertDataTable <UserDetails> (_sqlutil.GetObjectWithParam(query, _param));
        }

        public int GetUserId(string username, string password)
        {
            const string query = @"SELECT UserID FROM Users WHERE Username = @username AND Password = @password";

            _param = new List<SqlParameter>
            {
                new SqlParameter("username",username),
                new SqlParameter("password",password)
            };

            return _sqlutil.GetObjectId(query, _param);
        }

        public IEnumerable<UserSkills> GetUserSkillsById(int UserId)
        {
            const string query = @"SELECT UserSkillId, UserId, ShortName, LongName, SkillLevel 
                                   FROM UserSkills
                                   WHERE UserId = @UserId";

            _param = new List<SqlParameter>
            {
                new SqlParameter("UserID",UserId),
            };

            return EntityHelper.ConvertDataTable<UserSkills> (_sqlutil.GetObjectWithParam(query, _param));
        }

        public int GetAdminId(int userId)
        {
            const string query = @"SELECT AdminId FROM AppAdmin WHERE UserId = @UserId";

            _param = new List<SqlParameter>
            {
                new SqlParameter("UserID",userId),
            };

            return _sqlutil.GetObjectId(query, _param);
        }
    }
}
