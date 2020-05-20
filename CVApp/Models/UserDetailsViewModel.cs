using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVApp.Models
{
    public class UserDetailsViewModel
    {
        public int UserDetailsId { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Resume { get; set; }

        public bool Admin { get; set; }

        public List<SkillsViewModel> skills { get; set; }
    }
}