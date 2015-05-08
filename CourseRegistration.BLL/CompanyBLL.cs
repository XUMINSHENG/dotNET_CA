using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class CompanyBLL
    {
        private static readonly Lazy<CompanyBLL> lazy =
            new Lazy<CompanyBLL>(() => new CompanyBLL());
      
        public static CompanyBLL Instance { get { return lazy.Value; } }

        private CompanyBLL()
        {
        }

        public void CreateCompany(Company c)
        {
            IUnitOfWork uow = new UnitOfWork();

            uow.CompanyRepository.Insert(c);
            uow.Save();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            IUnitOfWork uow = new UnitOfWork();
            return uow.CompanyRepository.GetAll().ToList();
        }

        public Company GetCompanyById(int id)
        {
            IUnitOfWork uow = new UnitOfWork();
            return uow.CompanyRepository.GetById(id);
        }

        public void EditCompany(Company c)
        {
            IUnitOfWork uow = new UnitOfWork();
            uow.CompanyRepository.Edit(c);
            uow.Save();
            
        }

        public void DeleteCompany(Company c)
        {
            IUnitOfWork uow = new UnitOfWork();

            uow.CompanyRepository.Delete(c);
            uow.Save();
        }

    }
}
