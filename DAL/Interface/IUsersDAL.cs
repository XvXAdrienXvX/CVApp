using DAL.DTO;

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
        IEnumerable<dynamic> GetUserDetails();

        IEnumerable<dynamic> GetUsers();

        IEnumerable<dynamic> GetUserById(int UserId);

        int GetUserId(string username, string password);

        IEnumerable<dynamic> GetUserSkillsById(int UserId);
    }
}
