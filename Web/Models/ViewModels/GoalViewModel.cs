using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class GoalViewModel
    {
        public int GoalId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string UserId { get; set; }
    }
}