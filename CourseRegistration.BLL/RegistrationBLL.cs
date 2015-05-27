﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
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

            
            if (query.Count() == 0)
            {
                // Participant does not exist
                // Create New User
                var userRole = uow.AppRoleManager.FindByName("IndividualUser");
                ApplicationUser user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = r.Participant.IdNumber,
                    Email = r.Participant.Email,
                    PhoneNumber = r.Participant.ContactNumber,
                    isSysGenPassword = true
                };
                user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });

                String pwd = Util.GeneratePassword();

                uow.AppUserManager.Create(user, pwd);

                // Create New Participant
                r.Participant.AppUser = user;
                uow.ParticipantRepository.Insert(r.Participant);

            }
            else
            {
                // already exist
                // get participant record with same IdNo and Company == null
                Participant p = query.Single();

                // update exist one
                p.Salutation = r.Participant.Salutation;
                p.EmploymentStatus = r.Participant.EmploymentStatus;
                p.CompanyName = r.Participant.CompanyName;
                p.JobTitle = r.Participant.JobTitle;
                p.Department = r.Participant.Department;
                p.FullName = r.Participant.FullName;
                p.Gender = r.Participant.Gender;
                p.Nationality = r.Participant.Nationality;
                p.DateOfBirth = r.Participant.DateOfBirth;
                p.Email = r.Participant.Email;
                p.ContactNumber = r.Participant.ContactNumber;
                p.DietaryRequirement = r.Participant.DietaryRequirement;
                p.OrganizationSize = r.Participant.OrganizationSize;
                p.SalaryRange = r.Participant.SalaryRange;
                    
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
            else
            {

            }

            uow.RegistrationRepository.Insert(r);

            uow.Save();

        }

        public Registration getRegistrationById(int id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.RegistrationRepository.GetAll().Where(x=>x.RegistrationId==id)
                .Include(x=>x.Participant)
                .Include(x=> x.CourseClass)
                .Single();
        }

        public List<Registration> getAllRegistration()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.RegistrationRepository.GetAll().ToList();
        }

        public List<Registration> getRegistrationByConds(
            String categoryID, String courseCode, String classID,
            String participantName, String participantIdNumber, String participantCompanyName)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<Registration> query = 
                from reg in uow.RegistrationRepository.GetAll()
                select reg;

            if (categoryID.ToString() != Util.C_String_All_Select)
            {
                int tmpInt = int.Parse(categoryID);
                query = query.Where(x => x.CourseClass.Course.Category.CategoryId == tmpInt);
            }

            if (courseCode != Util.C_String_All_Select)
            {
                query = query.Where(x => x.CourseClass.Course.CourseCode == courseCode);
            }

            if (classID.ToString() != Util.C_String_All_Select)
            {
                query = query.Where(x => x.CourseClass.ClassId == classID);
            }

            if (participantName != Util.C_String_All_Select)
            {
                query = query.Where(x => x.Participant.FullName.ToUpper().Contains(participantName));
            }

            if (participantIdNumber != Util.C_String_All_Select)
            {
                query = query.Where(x => x.Participant.IdNumber.ToUpper().Contains(participantIdNumber));
            }

            if (participantCompanyName != Util.C_String_All_Select)
            {
                query = query.Where(x =>
                    x.Participant.Company.CompanyName.ToUpper().Contains(participantCompanyName)
                    || x.Participant.CompanyName.ToUpper().Contains(participantCompanyName));
            }

            return query.ToList();

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

    }
}
