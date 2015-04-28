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
        
        public static void CreateCourse(Course c)
        {
            using (IUnitOfWork uow = new UnitOfWork()) { 
                uow.CourseRepository.Insert(c);
                uow.Save();
            }
        }

        
    }
}

