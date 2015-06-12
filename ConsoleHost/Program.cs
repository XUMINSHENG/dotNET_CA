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

            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(CourseRegistration.Service.AttendanceService)))
            using (System.ServiceModel.ServiceHost host1 = new System.ServiceModel.ServiceHost(typeof(CourseRegistration.Service.CourseRegistrationService)))

            {
                host.Open();
                host1.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
