using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.BLL;
using CourseRegistration.Models;

namespace CourseRegistrationSystem.Areas.User.Controllers
{
    public class IndividualController : Controller
    {
        // GET: User/IndividualUser
        public ActionResult Index()
        {
            return View();
        }
    }
}