using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;

namespace BL
{
    public class UsersBL : IUsersBL
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
    }
}
