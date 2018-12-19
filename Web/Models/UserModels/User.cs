using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Models.GoalModels;
using Web.Models.SkillModels;

namespace Web.Models.UserModels
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, DateOfCreation.ToString()));
            userIdentity.AddClaim(new Claim(ClaimTypes.Gender, this.Gender));
            return userIdentity;
        }
        public DateTime? DateOfCreation { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public User()
        {
            Goals = new List<Goal>();
            Skills = new List<Skill>();
        }
    }
}