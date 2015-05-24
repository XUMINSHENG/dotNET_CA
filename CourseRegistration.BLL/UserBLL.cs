using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseRegistration.BLL
{
    public class UserBLL
    {
    private static readonly Lazy<UserBLL> lazy =
            new Lazy<UserBLL>(() => new UserBLL());
      
        public static UserBLL Instance { get { return lazy.Value; } }

        private UserBLL()
        {
        }

        public void CreateIndividualUser(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // Create New User
            var userRole = uow.AppRoleManager.FindByName(Util.C_Role_IndividualUser);
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = p.IdNumber,
                Email = p.Email,
                PhoneNumber = p.ContactNumber,
            };
            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });

            String pwd = Util.GeneratePassword();

            uow.AppUserManager.Create(user, pwd);

            // Create New Participant
            p.AppUser = user;
            uow.ParticipantRepository.Insert(p);
            uow.Save();

        }

        public void CreateCompanyHR(Company company, CompanyHR HR)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // Create New User
            var userRole = uow.AppRoleManager.FindByName(Util.C_Role_CompanyHR);
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = HR.Email,
                Email = HR.Email,
                PhoneNumber = HR.ContactNumber,
            };
            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });

            String pwd = Util.GeneratePassword();

            uow.AppUserManager.Create(user, pwd);

            // Create Comapany
            uow.CompanyRepository.Insert(company);

             // Create CompanyHR
            uow.CompanyHRRepository.Insert(HR);

            uow.Save();

        }

        public void CreateCourseAdmin(ApplicationUser user)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // Create New User
            var userRole = uow.AppRoleManager.FindByName(Util.C_Role_CourseAdmin);
            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
            String pwd = Util.GeneratePassword();

            uow.AppUserManager.Create(user, pwd);

            uow.Save();

        }

        public List<ApplicationUser> GetAllUsers()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.AppUserManager.Users.ToList();
        }

        public List<ApplicationUser> GetUsersByRole(String roleName)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            var requestRole = uow.AppRoleManager.FindByName(roleName);
            IQueryable<ApplicationUser> query = 
                from user in uow.AppUserManager.Users
                where
                    (from role in user.Roles where role.RoleId == requestRole.Id select true).FirstOrDefault() != null
                select user;

            return query.ToList();
        }

        public ApplicationUser GetUserById(String id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.AppUserManager.FindById(id);
        }

        public void DeleteUser(ApplicationUser user)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.AppUserManager.Delete(user);
            uow.Save();
            
        }

    }
}
