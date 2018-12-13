using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.GoalModels
{
    public class Goal
    {
        public int ID { get; set; }
        public StatusOfGoal StatusOfGoal { get; set; }
        public bool IsCompleted { get; set; }
    }
}