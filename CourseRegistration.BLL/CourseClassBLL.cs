using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
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

        public CourseClass GetCourseClassById(String courseClassId)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.CourseClassRepository.GetById(courseClassId);
        }

        public int getRegNum(String courseClassId)
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

            IQueryable<CourseClass> query =
                from courseClass in uow.CourseClassRepository.GetAll()
                where courseClass.isOpenForRegister &&
                    DateTime.Now < courseClass.StartDate && 
                    courseClass.Status != ClassStatus.Cancel
                select courseClass;

            return query.ToList();
        }

        public List<CourseClass> GetUpcomingClass()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            DateTime d = DateTime.Now.AddMonths(3);

            IQueryable<CourseClass> query =
                from courseClass in uow.CourseClassRepository.GetAll()
                where courseClass.isOpenForRegister &&
                    DateTime.Now < courseClass.StartDate &&
                    d > courseClass.StartDate &&
                    courseClass.Status != ClassStatus.Cancel
                select courseClass;

            return query.ToList();
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

        public List<Participant> GetStudentsByClassId(String classId)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            
            List<Registration> regList =
                uow.RegistrationRepository.GetAll()
                    .Where(x => x.CourseClass.ClassId == classId &&
                        x.Status == RegistrationStatus.Successful)
                .Include(x => x.Participant).ToList();

            List<Participant> studentList = new List<Participant>();
            foreach(Registration r in regList){
                studentList.Add(r.Participant);
            }

            return studentList;
        }

        public Boolean VerifyClass(String id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<CourseClass> query =
                from courseClass in uow.CourseClassRepository.GetAll()
                where courseClass.isOpenForRegister &&
                    DateTime.Now < courseClass.StartDate &&
                    courseClass.Status != ClassStatus.Cancel &&
                    courseClass.ClassId == id
                select courseClass;
            if (query.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean CancelClass(string classID)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            CourseClass courseClass = GetCourseClassById(classID);
            courseClass.Status = ClassStatus.Cancel;
            courseClass.isOpenForRegister = false;
            List<CourseClass> courseClassList = GetClassesByConds(Util.C_String_All_Select, courseClass.Course.CourseCode);
            CourseClass nextClass = null;

            foreach (CourseClass x in courseClassList)
            {
                if (x.StartDate > DateTime.Today && x.StartDate > courseClass.StartDate && x.Status != ClassStatus.Cancel)
                {
                    if (nextClass == null)
                        nextClass = x;
                    else if (x.StartDate < nextClass.StartDate)
                        nextClass = x;
                }
            }

            List<Registration> Reg = courseClass.Registrations;
            if (nextClass != null)
            {
                foreach (Registration r in Reg)
                {
                    r.CourseClass = nextClass;
                }
            }

            uow.CourseClassRepository.Edit(courseClass);
            uow.Save();
            return true;
        }

    }
}
