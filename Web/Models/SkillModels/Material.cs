using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.SkillModels
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}