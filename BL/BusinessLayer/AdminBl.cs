using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.DTO;
using DAL.Interface;
using System.Collections.Generic;
using System.Data;

namespace BL
{
    public class AdminBl : IAdminBL
    {
        private readonly IAdminDAL _adminDAL;

        public AdminBl(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public IEnumerable<dynamic> GetUsers(int adminId)
        {
            return _adminDAL.GetAllUsers(adminId);
        }

        public void CreateUser(Users user)
        {
            UsersDTO usrDTO = new UsersDTO
            {
                Username = user.Username,
                Email = user.Email,
                password = user.Password
            };

            _adminDAL.CreateUser(usrDTO);
        }

        public int GetAdminId(int userId)
        {
            return _adminDAL.GetAdminId(userId);
        }
    }
}
