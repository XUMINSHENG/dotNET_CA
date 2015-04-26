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
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;
        void Save();
    }

    public partial class UnitOfWork : IUnitOfWork
    {
        private CourseRegistrationContext _context;
        private IRepository<Category> _categoryRepository;
        private IRepository<Course> _courseRepository;
        private IRepository<CourseClass> _courseClassRepository;
        private IRepository<Registration> _registrationRepository;
        private IRepository<Participant> _participantRepository;
        private IRepository<Company> _companyRepository;

        public UnitOfWork()
        {
            _context = new CourseRegistrationContext();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            return new BaseRepository<TEntity>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
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

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
