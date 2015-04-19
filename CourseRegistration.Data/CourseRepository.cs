using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;

namespace CourseRegistration.Data
{
    public class CourseRepository
    {
        CourseContext db = new CourseContext();

        public Course getCourse(String title)
        {
            return db.Courses.Single(m => m.CourseTitle == title);
        }
    }
}
