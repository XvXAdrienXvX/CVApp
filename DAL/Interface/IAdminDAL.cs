using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IAdminDAL
    {
        IEnumerable<Users> GetAllUsers(int admiId);

        void CreateUser(Users users);

        int GetAdminId(int userId);
    }
}
