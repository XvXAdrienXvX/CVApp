using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Interface;
using System;
using System.Collections.Generic;

namespace BL
{
    public class UsersBL: IUsersBL
    {
        private readonly IUsersDAL _userDAL;
        private readonly IMapper _mapper;

        public UsersBL(IUsersDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public IEnumerable<UsersDTO> GetUsers()
        {
            yield return _mapper.Map<UsersDTO>(_userDAL.GetUsers());
        }

        public IEnumerable<UserDetailsDTO> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetailsDTO> GetUsersById(int UserId)
        {
            var userDetails = _userDAL.GetUserById(UserId);
            return _mapper.Map <IEnumerable<UserDetailsDTO>>(userDetails);
        }

        public int GetUserId(string username, string password)
        {
            return _userDAL.GetUserId(username, password);
        }

        public IEnumerable<UserSkillsDTO> GetUserSkillsById(int UserId)
        {
            yield return _mapper.Map <UserSkillsDTO>(_userDAL.GetUserSkillsById(UserId));
        }

        public int GetAdminId(int userId)
        {
            return _userDAL.GetAdminId(userId);
        }
    }
}
