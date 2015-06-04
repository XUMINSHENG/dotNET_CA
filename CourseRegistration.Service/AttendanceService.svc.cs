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


            return null;
        }


        public Result SubmitAttendance(String participantId, String classId)
        {

            return new Result(true, "");
        }
    }
}
