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
    public class RegistrationBLL
    {
        private static readonly Lazy<RegistrationBLL> lazy =
        new Lazy<RegistrationBLL>(() => new RegistrationBLL());

        private RegistrationBLL() { }

        public static RegistrationBLL Instance { get { return lazy.Value; } }


        public void CreateForIndividualUser(Registration r)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // Participant exists or not
            IQueryable<Participant> query = 
                from participant in uow.ParticipantRepository.GetAll()
                where
                    (participant.IdNumber == r.Participant.IdNumber && participant.Company == null)
                select participant;

            // Participant does not exist
            if (query.Count() == 0)
            {
                // Create New User
                var userRole = uow.AppRoleManager.FindByName("IndividualUser");
                ApplicationUser user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = r.Participant.IdNumber,
                    Email = r.Participant.Email,
                    PhoneNumber = r.Participant.ContactNumber,
                };
                user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });

                String pwd = GeneratePassword();

                uow.AppUserManager.Create(user, pwd);

                // Create New Participant
                r.Participant.AppUser = user;
                uow.ParticipantRepository.Insert(r.Participant);

            }


            // Create Registration
            uow.RegistrationRepository.Insert(r);
            
            
            uow.Save();
            
        }

        public void CreateForCompanyEmployee(Registration r)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // Participant exists or not
            IQueryable<Participant> query =
                from participant in uow.ParticipantRepository.GetAll()
                where
                    (participant.IdNumber == r.Participant.IdNumber && participant.Company == r.Participant.Company)
                select participant;

            // Participant does not exist
            if (query.Count() == 0)
            {
                // Create Participant

            }

            uow.RegistrationRepository.Insert(r);


            uow.Save();

        }

        public Registration getRegistrationById(int id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.RegistrationRepository.GetById(id);
        }

        public List<Registration> getAllRegistration()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.RegistrationRepository.GetAll().ToList();
             
        }

        public void UpdateRegistration(Registration r)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.RegistrationRepository.Edit(r);
            uow.Save();
             
        }

        public void DeleteRegistration(Registration r)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.RegistrationRepository.Delete(r);
            uow.Save();
             
        }

        private String GeneratePassword()
        {
            String pwd = "";
            String alphaStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String numStr = "1234567890";
            char[] alphaNumList = (alphaStr.ToUpper() + alphaStr.ToLower() + numStr).ToCharArray();
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                int indexVal = rnd.Next(0, alphaNumList.Length);
                pwd = pwd + alphaNumList[indexVal];
            }
            return pwd;
        }

    }
}
