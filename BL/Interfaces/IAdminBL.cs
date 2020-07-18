using BL.DTO;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IAdminBL
    {
        IEnumerable<UsersDTO> GetUsers(int adminId);

        void CreateUser(UsersDTO user);

        int GetAdminId(int userId);
    }
}
