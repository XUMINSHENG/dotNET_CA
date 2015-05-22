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
    public class ParticipantBLL
    {
    private static readonly Lazy<ParticipantBLL> lazy =
            new Lazy<ParticipantBLL>(() => new ParticipantBLL());
      
        public static ParticipantBLL Instance { get { return lazy.Value; } }

        private ParticipantBLL()
        {
        }

        public void CreateForIndividualUser(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            var userRole = uow.AppRoleManager.FindByName("IndividualUser");

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = p.IdNumber,
                Email = p.Email,
                PhoneNumber = p.ContactNumber
            };

            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });

            String pwd = p.generatePassword();


            uow.AppUserManager.Create(user, pwd);

            p.AppUser = user;
            uow.ParticipantRepository.Insert(p);
            uow.Save();

        }

        public void CreateForCompanyEmployee(Participant p)
        {

        }



        public List<Participant> GetAllParticipants()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.ParticipantRepository.GetAll().ToList();
            
        }

        public Participant GetParticipantById(int id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.ParticipantRepository.GetById(id);
            
        }

        public void EditParticipant(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.ParticipantRepository.Edit(p);
            uow.Save();
            
        }

        public void DeleteParticipant(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.ParticipantRepository.Delete(p);
            uow.Save();
            
        }
    }
}
