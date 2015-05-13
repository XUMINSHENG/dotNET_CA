using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;

namespace CourseRegistration.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Instructor> InstructorRepository{ get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Course> CourseRepository { get; }
        IRepository<CourseClass> CourseClassRepository { get; }
        IRepository<Registration> RegistrationRepository { get; }
        IRepository<Participant> ParticipantRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<CompanyHR> CompanyHRRepository { get; }
        IRepository<IndividualUser> IndividualUserRepository { get; }
        void Save();
    }

    public partial class UnitOfWork : IUnitOfWork
    {
        private CourseRegistrationContext _context;
        private IRepository<Instructor> _instructorRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<Course> _courseRepository;
        private IRepository<CourseClass> _courseClassRepository;
        private IRepository<Registration> _registrationRepository;
        private IRepository<Participant> _participantRepository;
        private IRepository<Company> _companyRepository;
        private IRepository<CompanyHR> _companyHRRepository;
        private IRepository<IndividualUser> _individualUserRepository;


        public UnitOfWork()
        {
            _context = new CourseRegistrationContext();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
            
        }

        public IRepository<Instructor> InstructorRepository
        {
            get
            {
                if (_instructorRepository == null)
                    _instructorRepository = new BaseRepository<Instructor>(_context);

                return _instructorRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new BaseRepository<Category>(_context);

                return _categoryRepository;
            }
        }

        public IRepository<Course> CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new BaseRepository<Course>(_context);

                return _courseRepository;
            }
        }

        public IRepository<CourseClass> CourseClassRepository
        {
            get
            {
                if (_courseClassRepository == null)
                    _courseClassRepository = new BaseRepository<CourseClass>(_context);

                return _courseClassRepository;
            }
        }

        public IRepository<Registration> RegistrationRepository
        {
            get
            {
                if (_registrationRepository == null)
                    _registrationRepository = new BaseRepository<Registration>(_context);

                return _registrationRepository;
            }
        }

        public IRepository<Participant> ParticipantRepository
        {
            get
            {
                if (_participantRepository == null)
                    _participantRepository = new BaseRepository<Participant>(_context);

                return _participantRepository;
            }
        }

        public IRepository<Company> CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new BaseRepository<Company>(_context);

                return _companyRepository;
            }
        }

        public IRepository<CompanyHR> CompanyHRRepository
        {
            get
            {
                if (_companyHRRepository == null)
                    _companyHRRepository = new BaseRepository<CompanyHR>(_context);

                return _companyHRRepository;
            }
        }

        public IRepository<IndividualUser> IndividualUserRepository
        {
            get
            {
                if (_individualUserRepository == null)
                    _individualUserRepository = new BaseRepository<IndividualUser>(_context);

                return _individualUserRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
