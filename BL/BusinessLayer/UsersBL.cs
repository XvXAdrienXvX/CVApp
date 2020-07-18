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

        public IEnumerable<UserDetailsDTO> GetUserDetailsById(int UserId)
        {
            var userDetails = _userDAL.GetUserDetailsById(UserId);
            return _mapper.Map <IEnumerable<UserDetailsDTO>>(userDetails);
        }

        public int GetUserId(string username, string password)
        {
            return _userDAL.GetUserId(username, password);
        }

        public IEnumerable<UserSkillsDTO> GetUserSkillsById(int UserId)
        {
            var userSkills = _userDAL.GetUserSkillsById(UserId);
            return _mapper.Map<IEnumerable<UserSkillsDTO>>(userSkills);
        }

        public int GetAdminId(int userId)
        {
            return _userDAL.GetAdminId(userId);
        }
    }
}
