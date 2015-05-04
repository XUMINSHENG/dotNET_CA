using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;


namespace CourseRegistrationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Category> categories = CategoryBLL.Instance.getAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult Course(string id)
        {
            Course course = CourseBLL.Instance.getCourseById(id);
            return View(course);
        }

        public ActionResult Classes()
        {
            return View();
        }

        public ActionResult Instructor()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //CourseRepository db = new CourseRepository();

           
            Category cate = new Category();
            cate.CategoryId = 1;
            cate.CategoryName = "NICF";

            Course c = new Course();
            c.CourseCode = "1";
            c.CourseTitle = "Agile Continuous Delivery";
            c.Category = cate;
            c.Fee = 866.70;
            c.NumberOfDays = 3;

            CourseBLL.Instance.CreateCourse(c);
                
            c = new Course();
            c.CourseCode = "2";
            c.CourseTitle = "Architecting Software Solutions";
            c.Fee = 1444.50;
            c.NumberOfDays = 5;

            CourseBLL.Instance.CreateCourse(c);
            
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //using (UnitOfWork uow = new UnitOfWork())
            //{
            //    IQueryable<Course> cl = uow.CourseRepository.GetAll().Where<Course>(x=>x.CourseTitle.Contains("Agile"));
                
            //    List<Course> c = cl.ToList<Course>();

            //    Console.WriteLine("hh");
            //}

            CourseBLL.Instance.SearchCourse("NICF");

            return View();
        }
    }
}