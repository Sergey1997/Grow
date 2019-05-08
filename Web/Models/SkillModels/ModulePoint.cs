using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.SkillModels
{
    public class ModulePoint
    {
        public int ModulePointId { get; set; }
        public string Description { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}