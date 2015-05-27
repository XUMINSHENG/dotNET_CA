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

        public CourseClass GetCourseClassById(int courseClassId)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.CourseClassRepository.GetAll().Where<CourseClass>(x => x.ClassId == courseClassId).Single(); 
            
        }

        public int getRegNum(int courseClassId)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            int result =
                (from reg in uow.RegistrationRepository.GetAll()
                where reg.Status != RegistrationStatus.Cancel &&
                reg.CourseClass.ClassId == courseClassId
                select 1).Count();

            return result;

        }

        public List<CourseClass> GetAllCourseClass()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.CourseClassRepository.GetAll().ToList();
            
        }

        public List<CourseClass> GetAvailableClass()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            List<CourseClass> list = new List<CourseClass>();
            foreach (CourseClass item in uow.CourseClassRepository.GetAll().ToList())
            {
                if (item.isOpenForRegister&&DateTime.Now<item.StartDate)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public void UpdateCourseClass(CourseClass cc)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.CourseClassRepository.Edit(cc);
            uow.Save();
        }

        public List<CourseClass> GetClassesByConds(String categoryID, String courseCode)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<CourseClass> query =
                from courseClass in uow.CourseClassRepository.GetAll()
                select courseClass;

            if (categoryID.ToString() != Util.C_String_All_Select)
            {
                int tmpInt = int.Parse(categoryID);
                query = query.Where(x => x.Course.Category.CategoryId == tmpInt);
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
