using DAL.DTO;
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

        //public IEnumerable<dynamic> GetAllUsers()
        //{
        //    string query = "SELECT * FROM Users";

        //    return _sqlutil.GetObject(query);
        //}

        public void CreateUser(UsersDTO users)
        {
            string query = "INSERT INTO Users(Username,Email,Password) VALUES (@Username,@Email,@Password)";

            _param = new List<SqlParameter>
            {
                new SqlParameter("Username",users.Username),
                new SqlParameter("Email",users.Email),
                new SqlParameter("Password",users.password)
            };

            _sqlutil.Insert(query, _param);
        }
    }
}
