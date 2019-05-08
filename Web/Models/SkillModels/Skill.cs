using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.UserModels;

namespace Web.Models.SkillModels
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Lections { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryOfSkill CategoryOfSkill { get; set; }
        public LevelOfSkill LevelOfSkill { get; set; } = LevelOfSkill.L1;
        public virtual ICollection<ModulePoint> Points { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}