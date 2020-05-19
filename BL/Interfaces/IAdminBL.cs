using BL.Models;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IAdminBL
    {
        IEnumerable<dynamic> GetUsers();

        void CreateUser(Users user);
    }
}
