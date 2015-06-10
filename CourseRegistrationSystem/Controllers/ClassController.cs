using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;
using CourseRegistrationSystem.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

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
        public ActionResult RegisterClass(String classId)
        {
            Registration r = new Registration();
            r.CourseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            r.Participant = new Participant();
            return View(r);
        }
        [HttpPost]
        public ActionResult RegisterClass(Registration r)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("IndividualUser"))
                {
                    return RedirectToAction("RegisterClassForIU");
                }
                if (User.IsInRole("CompanyHR"))
                {
                    return RedirectToAction("RegisterClassForHR");
                }
            }
            else
            {
                //verify if the user existed based on the information
                //if not, register a new one as individual user and finish the class registration
                //if yes, help them login and turn to iu action
            }
            return View(r);
        }

        [Authorize(Roles = "IndividualUser")]
        public ActionResult RegisterClassForIU(String classId)
        {
            Registration r = new Registration();
            r.CourseClass = CourseClassBLL.Instance.GetCourseClassById(classId);
            
            String loginUserId = User.Identity.GetUserId();
            r.Participant = ParticipantBLL.Instance.GetParticipantByUserId(loginUserId);

            return View(r);
        }
        [HttpPost]
        [Authorize(Roles = "IndividualUser")]
        public ActionResult RegisterClassForIU(Registration r)
        {
            //get result of registration & configure
            r.Sponsorship = Sponsorship.Self;
            r.DietaryRequirement = r.Participant.DietaryRequirement;
            
            //if success, go to confirm page
            if (RegistrationBLL.Instance.CreateForIndividualUser(r))
            {
                return View("RegisterClassForIUResult",r);
            }            
            //if no success return back 
            return View(r);
        }

        [Authorize(Roles = "CompanyHR")]
        public ActionResult RegisterClassForHR(String classId)
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;
            RegistrationViewModel r = new RegistrationViewModel();
            r.Participants = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(cmpId);
            r.CourseClass  = CourseClassBLL.Instance.GetCourseClassById(classId);
            
            return View(r);
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public ActionResult RegisterClassForHR(RegistrationViewModel r)
        {
            String id = Request.Form["p.IdNumber"];
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            Company company = loginHR.Company;
            String checkbox;
            Registration reg;
            List<Registration> rList = new List<Registration>();
            foreach (Participant item in r.Participants)
            {
                checkbox = null;
                checkbox = Request.Form[item.ParticipantId];
                if (checkbox != null && checkbox == item.ParticipantId.ToString())
                {
                    //selectedList.Add(item);
                    reg = new Registration();
                    reg.CourseClass = r.CourseClass;
                    reg.Participant = item;
                    reg.BillingAddress = r.BillingAddress;
                    reg.BillingPersonName = r.BillingPersonName;
                    reg.BillingAddressCountry = r.BillingAddressCountry;
                    reg.BillingAddressPostalCode = r.BillingAddressPostalCode;
                    reg.Sponsorship = Sponsorship.Company;
                    reg.OrganizationSize = company.OrganizationSize;
                    reg.DietaryRequirement = item.DietaryRequirement;
                    rList.Add(reg);
                }
            }
            if(rList.Count!=0){
                IEnumerable<Registration> failedList = RegistrationBLL.Instance.CreateForCompanyEmployee(rList);
                ViewBag.fList = failedList;
                return View(rList);
            }

            return View(r);
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
            //ViewBag.Participant = new Participant();
            return PartialView();
        }
        public class test
        {
            public String name { get; set; }
        }
        [HttpPost]
        public JsonResult CreateParticipant(Participant p)
        {
            String json = Request.Form["ParticipantList"];
            test[] data = JsonConvert.DeserializeObject<test[]>(json);
            return Json(data);
        }
        public ActionResult EditParticipant(Participant p)
        {
            return PartialView(p);
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