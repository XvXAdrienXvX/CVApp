using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BL.DTO
{
    public class AppAdminDTO
    {
        public int AdminID { get; set; }

        public int UserID { get; set; }

        public string Username { get; set; }

        public virtual List<UsersDTO> UsersList { get; set; }

        public AppAdminDTO()
        {
            UsersList = new List<UsersDTO>();
        }
    }
}