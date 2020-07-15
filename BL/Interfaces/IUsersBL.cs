using BL.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BL.Interfaces
{
    public interface IUsersBL
    {
        IEnumerable<UsersDTO> GetUsers();

        IEnumerable<UserDetailsDTO> GetUsersById(int UserId);

        IEnumerable<UserDetailsDTO> GetUserDetails();

        int GetUserId(string username, string password);

        IEnumerable<UserSkillsDTO> GetUserSkillsById(int UserId);

        int GetAdminId(int userId);
    }
}
