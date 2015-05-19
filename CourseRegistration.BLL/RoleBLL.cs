using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Messaging;

namespace CourseRegistration.BLL
{
    public class RoleBLL
    {
        private static readonly Lazy<RoleBLL> lazy =
            new Lazy<RoleBLL>(() => new RoleBLL());

        private RoleStore<IdentityRole> roleStore;
        private RoleManager<IdentityRole> roleManager;
        private UserStore<IdentityUser> userStore;
        private UserManager<IdentityUser> userManager;
        private IdentityDbContext identDbContext;

    public static RoleBLL Instance { get { return lazy.Value; } }

        private RoleBLL()
        {
            roleStore = new RoleStore<IdentityRole>();
            roleManager = new RoleManager<IdentityRole>(roleStore);
            userStore = new UserStore<IdentityUser>();
            userManager = new UserManager<IdentityUser>(userStore);
            identDbContext = new IdentityDbContext();
        }

        public int CreateRole(String roleName)
        {
            var role = new IdentityRole() { Name = roleName };
            IdentityRole roleIdentity = roleManager.FindByName(roleName);
            if (roleIdentity == null)
            {
                roleManager.Create(role);
                return 1;
            }
            return 0;
                
        }

        public List<String> GetAllRoles()
        {
            List<String> roleList = new List<string>();
            foreach(IdentityRole role in roleManager.Roles.ToList())
            {
                roleList.Add(role.Name);
            }
            return roleList;
            
        }

        public List<String> GetAllUsers()
        {
            List<String> userList = new List<string>();
            foreach(IdentityUser user in userManager.Users.ToList())
            {
                userList.Add(user.UserName);
            }
            return userList;
            
        }

        public List<String> GetUserRoles(String userName)
        {
            List<String> roleList = new List<string>();
            foreach (IdentityUserRole role in userManager.FindByName(userName).Roles.ToList())
            {
                roleList.Add(roleManager.FindById(role.RoleId).Name);
            }
            return roleList;

        }

        public void AssignRoleToUser(String userName,String roleName)
        {
            CreateRole(roleName);
            userManager.AddToRole(userManager.FindByName(userName).Id, roleName);            
        }

        public void UnAssignRoleToUser(String userName, String roleName)
        {
            userManager.RemoveFromRole(userManager.FindByName(userName).Id, roleName);
        }

        public void DeleteRole(String roleName)
        {
            var role = new IdentityRole() { Name = roleName };
            IdentityRole roleIdentity = identDbContext.Roles.FirstOrDefault(roleInst => roleInst.Name == roleName);
            identDbContext.Entry(roleIdentity);
            if (roleIdentity != null)
                identDbContext.Roles.Remove(roleIdentity);
            identDbContext.SaveChanges();
        }
    }
}
