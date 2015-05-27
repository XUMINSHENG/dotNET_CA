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

        public ActionResult RegisterClass(String id)
        {
            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(id);
            return View(courseClass);
        }
    }
}