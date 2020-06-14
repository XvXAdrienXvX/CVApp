using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class AppAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdminID { get; set; }

        public int UserID { get; set; }

        public string Username { get; set; }

        public virtual List<Users> UsersList { get; set; }

        public AppAdmin()
        {
            UsersList = new List<Users>();
        }
    }
}