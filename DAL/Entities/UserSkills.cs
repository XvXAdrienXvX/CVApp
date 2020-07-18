using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class UserSkills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSkillID{ get; set; }

        public int UserID { get; set; }

        public int SkillLevel { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }
    }
}