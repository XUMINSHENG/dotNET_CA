using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class AttendanceBLL
    {

        private static readonly Lazy<AttendanceBLL> lazy =
            new Lazy<AttendanceBLL>(() => new AttendanceBLL());

        public static AttendanceBLL Instance { get { return lazy.Value; } }

        private AttendanceBLL()
        {

        }

        public void CreateAttendance(Attendance attendance)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.AttendanceRepository.Insert(attendance);
            uow.Save();
        }
    }
}
