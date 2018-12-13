using System.Data.Entity;
using Web.Models.UserModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext() : base("GrowDB") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}