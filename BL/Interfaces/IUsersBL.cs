using BL.Models;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IUsersBL
    {
        IEnumerable<dynamic> GetUsers();

        IEnumerable<dynamic> GetUserDetails();
    }
}
