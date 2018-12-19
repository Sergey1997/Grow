using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.UserModels
{
    public class UserLogin : IdentityUserLogin
    {
        [Key]
        public int UserLoginId { get; set; }
        public UserLogin() { }
    }
}