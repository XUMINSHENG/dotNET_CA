﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistrationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //CourseRepository db = new CourseRepository();

            using (UnitOfWork uow = new UnitOfWork())
            {
                

                Course c = new Course();
                c.CourseCode = "2";
                c.CourseTitle = "Architecting Software Solutions";
                c.Fee = 1444.50;
                c.NumberOfDays = 5;

                uow.CourseRepository.Insert(c);
                uow.Save();
            }
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            using (UnitOfWork uow = new UnitOfWork())
            {
                IQueryable<Course> cl = uow.CourseRepository.GetAll().Where<Course>(x=>x.CourseTitle.Contains("Agile"));
                List<Course> c = cl.ToList<Course>();

                Console.WriteLine(c.First().Category);
            }

            return View();
        }
    }
}