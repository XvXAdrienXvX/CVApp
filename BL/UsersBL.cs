using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BL
{
    public class UsersBL: IUsersBL
    {
        private readonly IUsersDAL _userDAL;

        public UsersBL(IUsersDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IEnumerable<dynamic> GetUsers()
        {
            return  _userDAL.GetUsers();
        }

        public IEnumerable<dynamic> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> GetUsersById(int UserId)
        {
            return _userDAL.GetUserById(UserId);
        }

        public int GetUserId(string username, string password)
        {
            return _userDAL.GetUserId(username, password);
        }

        public IEnumerable<dynamic> GetUserSkillsById(int UserId)
        {
            return _userDAL.GetUserSkillsById(UserId);
        }

        public int GetAdminId(int userId)
        {
            return _userDAL.GetAdminId(userId);
        }
    }
}
