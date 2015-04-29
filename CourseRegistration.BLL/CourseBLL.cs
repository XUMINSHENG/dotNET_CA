using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public static class CourseBLL
    {
        static IUnitOfWork uow = new UnitOfWork();
        public static void CreateCourse(Course c)
        {
            uow.CourseRepository.Insert(c);
            uow.Save();
        }

        public static IQueryable<Course> GetAllCourses()
        {
            return uow.CourseRepository.GetAll();        
        }

        
    }
}

