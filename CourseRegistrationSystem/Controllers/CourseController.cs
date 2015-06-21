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
            List<Category> categories = CategoryBLL.Instance.GetAllCategories();
            
            return View(categories);
        }
        public ActionResult Search(String content)
        {
            List<Course> courses = new List<Course>(); ;
            if (!String.IsNullOrEmpty(content))
            {
                courses = CourseBLL.Instance.SearchCourse(content);
            }
            return View(courses);
        }
        [HttpPost]
        public ActionResult SearchResult()
        {
            String s = Request.Form["Search"];
            List<Course> courses = CourseBLL.Instance.SearchCourse(s);
            return PartialView("SearchResult",courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(string code)
        {
            Course course = CourseBLL.Instance.GetCourseByCode(code);
            return View(course);
        }

        public ActionResult CourseList(int categoryId)
        {
            Category category = CategoryBLL.Instance.GetCategoryById(categoryId);
            return PartialView(category);
        }
    }
}
