﻿using DAL.DTO;
using DAL.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUsersDAL
    {
        IEnumerable<UserDetails> GetUserDetails();

        IEnumerable<Users> GetUsers();

        IEnumerable<UserDetails> GetUserDetailsById(int UserId);

        int GetUserId(string username, string password);

        IEnumerable<UserSkills> GetUserSkillsById(int UserId);

        int GetAdminId(int userId);
    }
}
