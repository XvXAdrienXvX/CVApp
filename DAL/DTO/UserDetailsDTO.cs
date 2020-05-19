using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.DTO
{
    public class UserDetailsDTO
    {
        public int UserDetailsId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Resume { get; set; }
    }
}