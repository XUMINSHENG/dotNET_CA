using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class CourseBLL
    {

        private static IUnitOfWork uow = new UnitOfWork();
        private static readonly Lazy<CourseBLL> lazy =
            new Lazy<CourseBLL>(() => new CourseBLL());
      
        public static CourseBLL Instance { get { return lazy.Value; } }

        private CourseBLL()
        {
        }


        public void CreateCourse(Course c)
        {
            uow.CourseRepository.Insert(c);
            uow.Save();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return uow.CourseRepository.GetAll().ToList();
        }

        public Course GetCourseById(String courseCode)
        {
            return uow.CourseRepository.GetAll().Where<Course>(x => x.CourseCode == courseCode).Single();
        }

        public IEnumerable<Course> SearchCourse(String key)
        {
            IQueryable<Course> result;
            String keyWord = key.ToUpper();
            //title
            IQueryable<Course> titleQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.CourseTitle.ToUpper().Contains(keyWord));
            //category
            IQueryable<Course> categoryQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.Category.CategoryName.ToUpper().Contains(keyWord));
            //instructor
            IQueryable<Course> instructorQuery = from course in uow.CourseRepository.GetAll() 
                              where
                                  (from instructor in course.Instructors where instructor.InstructorName.ToUpper().Contains(keyWord) select true).FirstOrDefault() != null
                              select course;

            //description
            IQueryable<Course> descriptionQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.CourseDescription.ToUpper().Contains(keyWord));

            result = titleQuery.Union(categoryQuery).Union(instructorQuery).Union(descriptionQuery);
            return result.ToList();
        }





    }
}

