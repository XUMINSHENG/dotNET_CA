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
       
        private static readonly Lazy<CourseClassBLL> lazy =
            new Lazy<CourseClassBLL>(() => new CourseClassBLL());

        private CourseClassBLL() { }

        public static CourseClassBLL Instance { get { return lazy.Value; } }


        public void CreateCourseClass(CourseClass cc)
        {
            using (IUnitOfWork uow = new UnitOfWork()) {
            uow.CourseClassRepository.Insert(cc);
            uow.Save();
        }
        }

        public CourseClass getCourseClassById(int courseClassCode)
        {
            using (IUnitOfWork uow = new UnitOfWork()) { 
                return uow.CourseClassRepository.GetAll().Where<CourseClass>(x => x.ClassId == courseClassCode).Single(); 
            }
        }

        public IEnumerable<CourseClass> getAllCourseClass()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.CourseClassRepository.GetAll().ToList();
            }
        }

        public void UpdateCourseClass(CourseClass cc)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                uow.CourseClassRepository.Edit(cc);
                uow.Save();
            }
        }

        public void DeleteCourseClass(CourseClass cc)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                uow.CourseClassRepository.Delete(cc);
                uow.Save();
            }
        }

//        public IEnumerable<> GetAttendSheet()
//      {
//        }

    }
}
