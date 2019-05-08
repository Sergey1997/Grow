using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.SkillModels
{
    public class Task
    {
        public int TaskId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}