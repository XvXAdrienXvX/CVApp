using BL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BL.Interfaces
{
    public interface IUsersBL
    {
        IEnumerable<dynamic> GetUsers();

        IEnumerable<dynamic> GetUsersById(int UserId);

        IEnumerable<dynamic> GetUserDetails();

        int GetUserId(string username, string password);
    }
}
