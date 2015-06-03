using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;

namespace CourseRegistrationSystem.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            IEnumerable<CourseClass> classes = CourseClassBLL.Instance.GetAvailableClass();

            return View(classes);
        }

        public ActionResult Details(String id)
        {
            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(id);
            return View(courseClass);
        }

        public ActionResult RegisterClassForIU(String classId, String userId)
        {
            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            //get personal details to pre fill paticipant details

            return View(courseClass);
        }

        public ActionResult RegisterClassForHR(String classId, int cmpId)
        {
            Registration registration = new Registration();

            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            IEnumerable<Participant> participants = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(cmpId);
            ViewBag.CourseClass = courseClass;
            ViewBag.EmployeeList = participants;

            return View(courseClass);
        }

    }
}