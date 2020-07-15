using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BL.DTO
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

        public bool Admin { get; set; }

        public List<SkillsDTO> Skills { get; set; } = new List<SkillsDTO>();
    }
}