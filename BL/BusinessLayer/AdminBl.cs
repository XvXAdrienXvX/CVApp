using BL.Interfaces;
using BL.DTO;
using DAL.Interface;
using System.Collections.Generic;
using DAL.Entities;
using AutoMapper;

namespace BL
{
    public class AdminBl : IAdminBL
    {
        private readonly IAdminDAL _adminDAL;
        private readonly IMapper _mapper;

        public AdminBl(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public IEnumerable<UsersDTO> GetUsers(int adminId)
        {
            var userModel = _adminDAL.GetAllUsers(adminId);
            yield return _mapper.Map<UsersDTO>(userModel);
        }

        public void CreateUser(UsersDTO user)
        {
            Users usrDTO = new Users
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            _adminDAL.CreateUser(usrDTO);
        }

        public int GetAdminId(int userId)
        {
            return _adminDAL.GetAdminId(userId);
        }
    }
}
