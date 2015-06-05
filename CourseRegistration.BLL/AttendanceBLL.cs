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
            ValidateAttendance(attendance);

            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.AttendanceRepository.Insert(attendance);
            uow.Save();
        }

        public List<Attendance> GetAttendanceByClassAndParticipant(String classId, int participantId)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<Attendance> query =
                from attend in uow.AttendanceRepository.GetAll()
                where attend.CourseClass.ClassId == classId &&
                    attend.Participant.ParticipantId == participantId
                select attend;

            return query.ToList();
        }

        private void ValidateAttendance(Attendance attendance)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

            // student exists
            if (attendance.Participant == null || 
                uow.ParticipantRepository.GetById(attendance.Participant.ParticipantId) == null)
            {
                throw new BusinessException("invalid Participant");
            }

            // class exists
            if (attendance.CourseClass == null || 
                uow.CourseClassRepository.GetById(attendance.CourseClass.ClassId) == null)
            {
                throw new BusinessException("invalid Class");
            }

            // previous record exists
            if (GetCountByClassAndParticipantAndDate(
                attendance.CourseClass.ClassId,
                attendance.Participant.ParticipantId,
                attendance.ClassDate) != 0)
            {
                throw new BusinessException("Attendance already exist");
            }
        }

        public int GetCountByClassAndParticipantAndDate(String classId, int participantId, DateTime date)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            IQueryable<Attendance> query =
                from attend in uow.AttendanceRepository.GetAll()
                where attend.CourseClass.ClassId == classId &&
                    attend.Participant.ParticipantId == participantId &&
                    attend.ClassDate == date
                select attend;

            return query.Count();
        }

    }
}
