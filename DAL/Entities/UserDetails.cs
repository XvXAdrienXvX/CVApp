using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entites
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserDetailsId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Resume { get; set; }

        public string Username { get; set; }

        public bool Admin { get; set; }

        public virtual List<Skills> skills { get; set; }

        public UserDetails()
        {
            skills = new List<Skills>();
        }
    }
}