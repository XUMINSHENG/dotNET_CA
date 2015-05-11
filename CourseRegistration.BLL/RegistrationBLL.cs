using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class RegistrationBLL
    {
        private static readonly Lazy<RegistrationBLL> lazy =
        new Lazy<RegistrationBLL>(() => new RegistrationBLL());

        private RegistrationBLL() { }

        public static RegistrationBLL Instance { get { return lazy.Value; } }


        public void CreateRegistration(Registration r)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.RegistrationRepository.Insert(r);
            uow.Save();
            
        }

        public Registration getRegistrationById(int id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.RegistrationRepository.GetById(id);
        }

        public IEnumerable<Registration> getAllRegistration()
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

    }
}
