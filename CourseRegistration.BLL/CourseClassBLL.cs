using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class CourseClassBLL
    {
        private static IUnitOfWork uow = new UnitOfWork();
        private static readonly Lazy<CourseClassBLL> lazy =
            new Lazy<CourseClassBLL>(() => new CourseClassBLL());

        public static CourseClassBLL Instance { get { return lazy.Value; } }

        public void CreateCourseClass(CourseClass cc)
        {
            uow.CourseClassRepository.Insert(cc);
            uow.Save();
        }

        public CourseClass getCourseClassById(int courseClassCode)
        {
            return uow.CourseClassRepository.GetAll().Where<CourseClass>(x => x.ClassId == courseClassCode).Single();
        }

        public IEnumerable<CourseClass> getAllCourseClass()
        {
            return uow.CourseClassRepository.GetAll().ToList();
        }

        public bool CloseClass(int classID)
        {
            return false;
        }

    }
}
