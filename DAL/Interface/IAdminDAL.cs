using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAdminDAL
    {
        //IEnumerable<dynamic> GetAllUsers();

        void CreateUser(UsersDTO users);    
    }
}
