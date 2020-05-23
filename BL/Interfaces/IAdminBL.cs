using BL.Models;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IAdminBL
    {
        IEnumerable<dynamic> GetUsers(int adminId);

        void CreateUser(Users user);

        int GetAdminId(int userId);
    }
}
