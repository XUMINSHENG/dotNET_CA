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
        IRepository<Category> CategoryRepository { get; }
        IRepository<Course> CourseRepository { get; }
        void Save();
    }

    public partial class UnitOfWork : IUnitOfWork
    {

        private IRepository<Category> _categoryRepository;
        private IRepository<Course> _courseRepository;
        private CourseRegistrationContext _context;

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

        public UnitOfWork()
        {
            _context = new CourseRegistrationContext();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
