using System.Data.Entity;
using Web.Models.UserModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Models.SkillModels;
using Web.Models.GoalModels;

namespace Web.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<CategoryOfSkill> Categories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public ApplicationContext() : base("GrowDB") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}