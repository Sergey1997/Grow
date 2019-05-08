using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.UserModels;

namespace Web.Models.RoleModels
{
    public class EditRoleModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public List<ApplicationRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public EditRoleModel()
        {
            AllRoles = new List<ApplicationRole>();
            UserRoles = new List<string>();
        }
    }
}