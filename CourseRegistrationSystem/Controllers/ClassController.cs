using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;
using CourseRegistrationSystem.Models;
using Microsoft.AspNet.Identity;


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
        
        public ActionResult RegisterClassForIU(String classId)
        {
            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            ViewBag.CourseClass = courseClass;
            //get personal details to pre fill paticipant details

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "IndividualUser")]
        public ActionResult RegisterClassForIU(String classId, ParticipantViewModel participant, BillingViewModel billing)
        {
            return View();
        }
        [Authorize(Roles = "CompanyHR")]
        public ActionResult RegisterClassForHR(String classId)
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;

            Registration registration = new Registration();

            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            ViewBag.CourseClass = courseClass;
            return View();
        }
        [Authorize(Roles = "CompanyHR")]
        [HttpPost]
        public ActionResult RegisterClassForHR(String classId, List<ParticipantViewModel> participants, BillingViewModel billing)
        {
            return View();
        }
        public ActionResult GetEmployeeList()
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;
            IEnumerable<Participant> participants = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(cmpId);
            return PartialView(participants);
        }
        public ActionResult CreateParticipant()
        {
            Participant participant = new Participant();
            return PartialView(participant);
        }
        public ActionResult CreateBilling()
        {
            BillingViewModel billing = new BillingViewModel();
            return PartialView(billing);
        }
        [HttpPost]
        public ActionResult GetParticipantFromList(List<int> array)
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;
            IEnumerable<Participant> participants = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(cmpId);
            
            List<Participant> list = new List<Participant>();
            foreach (int i in array)
            {
                
                foreach (Participant p in participants)
                {
                    if (i == p.ParticipantId)
                    {
                        list.Add(p);
                    }
                } 
            }
            return PartialView(list);
        }
    }
}