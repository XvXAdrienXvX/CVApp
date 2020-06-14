using DAL.DTO;
using DAL.Entities;
using DAL.HelperUtils;
using DAL.Interface;
using SQLUtils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdminDAL: IAdminDAL
    {
        private readonly ISQLUtils _sqlutil;
        private  List<SqlParameter> _param;

        public AdminDAL()
        {
            _sqlutil = new SQLUtils.SQLUtils();
        }

        public IEnumerable<Users> GetAllUsers(int adminId)
        {
            const string query = @"SELECT U.Username,U.Email,U.Phone,U.Password
                                   FROM Users AS U
                                   JOIN AppAdmin AS AA ON U.UserID = AA.UserId
                                   WHERE AA.AdminID = @AdminId";

            _param = new List<SqlParameter>
            {
                new SqlParameter("AdminId",adminId)
            };

            return EntityHelper.ConvertDataTable<Users>(_sqlutil.GetObjectWithParam(query, _param));
        }

        public void CreateUser(UsersDTO users)
        {
            string query = @"INSERT INTO Users(Username,Email,Password) VALUES (@Username,@Email,@Password)";

            _param = new List<SqlParameter>
            {
                new SqlParameter("Username",users.Username),
                new SqlParameter("Email",users.Email),
                new SqlParameter("Password",users.password)
            };

            _sqlutil.Insert(query, _param);
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
