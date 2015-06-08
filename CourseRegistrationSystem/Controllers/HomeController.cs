using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;
using CourseRegistration.Models;

namespace CourseRegistrationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.cList = CourseClassBLL.Instance.GetUpcomingClass();
            return View();
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