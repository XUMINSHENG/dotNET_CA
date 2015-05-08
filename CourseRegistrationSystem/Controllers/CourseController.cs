using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;

namespace CourseRegistrationSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> courses = CourseBLL.Instance.GetAllCourses();

            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(string id)
        {
            Course course = CourseBLL.Instance.GetCourseById(id);
            return View(course);
        }

        public ActionResult CourseList(int categoryId)
        {
            Category category = CategoryBLL.Instance.GetCategoryById(categoryId);
            return PartialView(category);
        }
    }
}
