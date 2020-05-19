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

        public AdminBl()
        {
            _adminDAL = new AdminDAL();
        }

        public IEnumerable<dynamic> GetUsers()
        {
           return _adminDAL.GetAllUsers();           
        }

        public void CreateUser(Users user)
        {
            UsersDTO usrDTO = new UsersDTO
            {
                Username = user.Username,
                Email = user.Email,
                password = user.password
            };

            _adminDAL.CreateUser(usrDTO);
        }
    }
}
