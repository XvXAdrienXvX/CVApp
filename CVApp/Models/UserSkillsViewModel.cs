using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVApp.Models
{
    public class UserSkillsViewModel
    {
        public int UserSkillID { get; set; }

        public int UserID { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }

        public int SkillLevel { get; set; }

        public virtual List<SkillsViewModel> UserSkillList { get; set; }

        public UserSkillsViewModel()
        {
            UserSkillList = new List<SkillsViewModel>();
        }
    }
}