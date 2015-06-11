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
            int cmpId = GetCompanyId();
            ViewBag.Participants = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(cmpId);
            ViewBag.CourseClass  = CourseClassBLL.Instance.GetCourseClassById(classId);
            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public ActionResult RegisterClassForHR()
        {
            String classId = Request.Form["ClassId"];
            ViewBag.CourseClass = CourseClassBLL.Instance.GetCourseClassById(classId);

            ViewBag.Address = Request.Form["Address"];
            ViewBag.Country = Request.Form["Country"];
            ViewBag.Postalcode = Request.Form["PostalCode"];
            ViewBag.PersonName = Request.Form["PersonName"];

            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            Company company = loginHR.Company;
            
            Registration reg;
            List<Registration> rList = new List<Registration>();

            String jsonString = Request.Form["NewParticipantList"];
            Participant[] participants = JsonConvert.DeserializeObject<Participant[]>(jsonString);

            foreach (Participant item in participants)
            {
                   
                    //selectedList.Add(item);
                    reg = new Registration();
                    reg.CourseClass = ViewBag.CourseClass;
                    reg.Participant = item;
                    reg.BillingAddress = ViewBag.Address;
                    reg.BillingPersonName = ViewBag.PersonName;
                    reg.BillingAddressCountry = ViewBag.Country;
                    reg.BillingAddressPostalCode = ViewBag.PostalCode;
                    reg.Sponsorship = Sponsorship.Company;
                    reg.OrganizationSize = company.OrganizationSize;
                    reg.DietaryRequirement = item.DietaryRequirement;
                    rList.Add(reg);
                
            }
            if (rList.Count != 0)
            {
                IEnumerable<Registration> failedList = RegistrationBLL.Instance.CreateForCompanyEmployee(rList);
                ViewBag.fList = failedList;
                return View();
            }

            return View();
        }
        public int GetCompanyId()
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;
            
            return cmpId;
        }
        public ActionResult CreateParticipant()
        {
            Participant p = new Participant();

            return PartialView(p);
        }
        [HttpPost]
        public Boolean CreateParticipant(Participant p)
        {
            //String jsonString = Request.Form["NewParticipant"];
            //Participant[] participants = JsonConvert.DeserializeObject<Participant[]>(jsonString);
            //return Json(participants);
            int cmpId = GetCompanyId();
            List<Participant> newList = (List<Participant>)Session["NewParticipant"];
            if(Session["NewParticipant"] == null || newList.Count == 0){
                if(ParticipantBLL.Instance.GetCmpParticipantByIdNumber(cmpId,p.IdNumber).Count == 0){
                    
                }
                return true;
            }else{
                return false;
            }
            //Session["NewParticipantList"] = 
            
        }
        public ActionResult EditParticipant(List<Participant> pList)
        {
            return PartialView(pList);
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