using DAL.Entities;
using System.Collections.Generic;

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
