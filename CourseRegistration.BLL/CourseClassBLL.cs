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
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.CourseClassRepository.Insert(cc);
            uow.Save();
        
        }

        public CourseClass GetCourseClassById(int courseClassCode)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.CourseClassRepository.GetAll().Where<CourseClass>(x => x.ClassId == courseClassCode).Single(); 
            
        }

        public List<CourseClass> GetAllCourseClass()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.CourseClassRepository.GetAll().ToList();
            
        }

        public void UpdateCourseClass(CourseClass cc)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.CourseClassRepository.Edit(cc);
            uow.Save();
        }

        public List<CourseClass> GetClassesByConds(int categoryID, string courseCode)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<CourseClass> query =
                from courseClass in uow.CourseClassRepository.GetAll()
                select courseClass;

            if (categoryID.ToString() != Util.C_String_All_Select)
            {
                query = query.Where(x => x.Course.Category.CategoryId == categoryID);
            }

            if (courseCode != Util.C_String_All_Select)
            {
                query = query.Where(x => x.Course.CourseCode == courseCode);
            }


            return query.ToList(); 
            
        }

        public void DeleteCourseClass(CourseClass cc)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.CourseClassRepository.Delete(cc);
            uow.Save();
        }

        //        public List<> GetAttendSheet()
//      {
//        }

    }
}
