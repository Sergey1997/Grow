using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class CreateTaskViewModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int SkillId { get; set; }
        public virtual ICollection<MaterialViewModel> Materials { get; set; }
    }
}