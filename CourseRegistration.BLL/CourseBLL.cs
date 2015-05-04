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

        public List<Course> GetAllCourses()
        {
            return uow.CourseRepository.GetAll().ToList();
        }

        public Course getCourseById(String courseCode)
        {
            return uow.CourseRepository.GetAll().Where<Course>(x => x.CourseCode == courseCode).Single();
        }

        public IEnumerable<Course> SearchCourse(String keyWord)
        {
            IQueryable<Course> result;

            //result.AddRange(uow.CourseRepository.GetAll().Where<Course>(x => searchFunc(x,keyWord)).ToList<Course>());

            //title
            IQueryable<Course> titleQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.CourseTitle.ToUpper().Contains(keyWord.ToUpper()));
            //category
            IQueryable<Course> categoryQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.Category.CategoryName.ToUpper().Contains(keyWord.ToUpper()));
            //instructor
            IQueryable<Course> instructorQuery = uow.CourseRepository.GetAll();
                //Where<Course>(x => x.Instructors.Where(y => y.InstructorName.ToUpper().Contains(keyWord.ToUpper())));

            instructorQuery = from course in instructorQuery 
                              where
                                  (from instructor in course.Instructors where instructor.InstructorName.ToUpper().Contains(keyWord.ToUpper()) select true).FirstOrDefault() != null
                              select course;
                                 // (x=>x.InstructorName.ToUpper().Contains(keyWord.ToUpper())) select ins;

            //description
            IQueryable<Course> descriptionQuery = uow.CourseRepository.GetAll().Where<Course>(x => x.CourseDescription.ToUpper().Contains(keyWord.ToUpper()));

            //result = titleQuery.Union(categoryQuery).Union(instructorQuery).Union(descriptionQuery);
            result = titleQuery;
            return result.ToList();

        }

        delegate bool searchDelegate(Course course, String keyWord);
        searchDelegate searchFunc = (course, keyWord) =>
        {
            bool result = false;

            if (course.CourseTitle.ToUpper().Contains(keyWord.ToUpper()))
            {
                result = true;
            }

            if(course.Category.CategoryName.ToUpper().Contains(keyWord.ToUpper()))
            {
               result = true;
            }

            foreach(Instructor instructor in course.Instructors){
                if (instructor.InstructorName.ToUpper().Contains(keyWord.ToUpper()))
                {
                    result = true;
                    break;
                }
            }
            
            if (course.CourseDescription.ToUpper().Contains(keyWord.ToUpper()))
            {
                result = true;
            }
            return result;

        };




    }
}

