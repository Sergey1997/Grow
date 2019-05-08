using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SkillViewModel> Skills { get; set; }
    }
}