using System;
using KMM.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KMM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName
        {
            get { return String.Concat(FirstName, " ", LastName); }
        }
        public Department Department { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("KMMEntities")
        {
        }
    }

    public class IdentityManager
    {
        private RoleManager<IdentityRole> RoleManager { get; set; } 
        public IdentityManager()
        {
            RoleManager = RoleManager ?? new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }
        public bool RoleExists(string roleName)
        {
            return RoleManager.RoleExists(roleName);
        }

        public bool CreateRole(string roleName)
        {
            return RoleManager.Create(new IdentityRole(roleName)).Succeeded;
        }
    }
}