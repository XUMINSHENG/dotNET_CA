using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {

            using (System.ServiceModel.ServiceHost host_Attendance_Service = new System.ServiceModel.ServiceHost(typeof(CourseRegistration.Service.AttendanceService)))
            using (System.ServiceModel.ServiceHost host_Course_Registration_Service = new System.ServiceModel.ServiceHost(typeof(CourseRegistration.Service.CourseRegistrationService)))

            {
                host_Attendance_Service.Open();
                host_Course_Registration_Service.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
