using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.SkillModels
{
    public class CategoryOfSkill
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}