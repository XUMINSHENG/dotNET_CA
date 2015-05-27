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

        private IUnitOfWork uow;

    public static RoleBLL Instance { get { return lazy.Value; } }

        private RoleBLL()
        {
            uow = new UnitOfWork();
        }

        public int CreateRole(String roleName)
        {
            var role = new IdentityRole() { Name = roleName };
            IdentityRole roleIdentity = uow.AppRoleManager.FindByName(roleName);
            if (roleIdentity == null)
            {
                uow.AppRoleManager.Create(role);
                return 1;
            }
            return 0;
                
        }

        public List<String> GetAllRoles()
        {
            List<String> roleList = new List<string>();
            foreach(IdentityRole role in uow.AppRoleManager.Roles.ToList())
            {
                roleList.Add(role.Name);
            }
            return roleList;
            
        }

        public List<String> GetAllUsers()
        {
            List<String> userList = new List<string>();
            foreach (IdentityUser user in uow.AppUserManager.Users.ToList())
            {
                userList.Add(user.UserName);
            }
            return userList;
            
        }

        public List<String> GetUserRoles(String userName)
        {
            List<String> roleList = new List<string>();
            foreach (IdentityUserRole role in uow.AppUserManager.FindByName(userName).Roles.ToList())
            {
                roleList.Add(uow.AppRoleManager.FindById(role.RoleId).Name);
            }
            return roleList;

        }

        public void AssignRoleToUser(String userName,String roleName)
        {
            uow.AppUserManager.AddToRole(uow.AppUserManager.FindByName(userName).Id, roleName);            
        }

        public void UnAssignRoleToUser(String userName, String roleName)
        {
            uow.AppUserManager.RemoveFromRole(uow.AppUserManager.FindByName(userName).Id, roleName);
        }

        public void DeleteRole(String roleName)
        {
            uow.AppRoleManager.Delete(uow.AppRoleManager.FindByName(roleName));
        }
    }
}
