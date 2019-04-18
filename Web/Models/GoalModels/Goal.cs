using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.GoalModels
{
    public class Goal
    {
        public int GoalId { get; set; }
        public string Description { get; set; }
        public StatusOfGoal StatusOfGoal { get; set; } = StatusOfGoal.Planned;
        public bool IsCompleted { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int UserId { get; set; }
        public virtual UserModels.User User { get; set; }
    }
}