using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CourseRegistration.Models;
using CourseRegistration.BLL;


namespace CourseRegistration.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AttendanceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AttendanceService.svc or AttendanceService.svc.cs at the Solution Explorer and start debugging.
    public class AttendanceService : IAttendanceService
    {
        public List<SvcStudent> GetStudentList(DateTime date, String classId)
        {

            String userName = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;

            List<SvcStudent> studentList = new List<SvcStudent>();

            List<Participant> participantList = CourseClassBLL.Instance.GetStudentsByClassId(classId);
            foreach (Participant p in participantList)
            {
                SvcStudent newStud = new SvcStudent(
                    p.ParticipantId,
                    p.IdNumber,
                    p.FullName,
                    (Service.Gender)p.Gender,
                    p.Nationality,
                    p.Email,
                    p.ContactNumber
                );
                studentList.Add(newStud);
            }

            return studentList;
        }


        public Result SubmitAttendance(int participantId, String classId)
        {
            try
            {
                Attendance att = new Attendance();
                att.Participant = ParticipantBLL.Instance.GetParticipantById(participantId);
                att.CourseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
                att.ClassDate = DateTime.Today;
                AttendanceBLL.Instance.CreateAttendance(att);
            }
            catch (BusinessException e)
            {
                return new Result(false, e.ToString());
            }
            return new Result(true, "");
        }
    }
}
