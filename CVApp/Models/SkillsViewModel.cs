using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVApp.Models
{
    public class SkillsViewModel
    {
        public int SkillId { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }

        public int SkillLevel { get; set; }
    }
}