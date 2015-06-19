﻿using System;
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
    //private ApplicationUserManager _userManager;
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

                //var user = CourseRegistration.BLL.UserBLL.Instance.CreateIndividualUser(r.Participant);
                //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                //return RedirectToAction("Index", "Home");
                
            }
            return View(r);
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

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
            r.CourseClass = CourseClassBLL.Instance.GetCourseClassById(r.CourseClass.ClassId);
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
            Session["ParticipantList"] = new List<Participant>();
            Session["EmployeeList"] = new List<Participant>();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public ActionResult RegisterClassForHR()
        {
            String classId = Request.Form["ClassId"];
            ViewBag.CourseClass = CourseClassBLL.Instance.GetCourseClassById(classId);

            List<Participant> newParticipant = (List<Participant>)Session["ParticipantList"];
            List<Participant> oldParticipant = (List<Participant>)Session["EmployeeList"];

            ViewBag.Address = Request.Form["Address"];
            ViewBag.Country = Request.Form["Country"];
            ViewBag.Postalcode = Request.Form["PostalCode"];
            ViewBag.PersonName = Request.Form["PersonName"];

            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            Company company = loginHR.Company;
            
            Registration reg;
            List<Registration> rList = new List<Registration>();

            //String jsonString = Request.Form["NewParticipantList"];
            //Participant[] participants = JsonConvert.DeserializeObject<Participant[]>(jsonString);

            if (newParticipant.Count != 0)
            {
                foreach (Participant item in newParticipant)
                {
                    reg = new Registration();
                    reg.CourseClass = ViewBag.CourseClass;
                    reg.Participant = item;
                    reg.Participant.Company = company;
                    reg.BillingAddress = ViewBag.Address;
                    reg.BillingPersonName = ViewBag.PersonName;
                    reg.BillingAddressCountry = ViewBag.Country;
                    reg.BillingAddressPostalCode = ViewBag.PostalCode;
                    reg.Sponsorship = Sponsorship.Company;
                    reg.OrganizationSize = company.OrganizationSize;
                    reg.DietaryRequirement = item.DietaryRequirement;
                    rList.Add(reg);
                }
            }

            if (oldParticipant.Count != 0)
            {
                foreach (Participant item in oldParticipant)
                {
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
            }
            
            if (rList.Count != 0)
            {
                IEnumerable<Registration> failedList = RegistrationBLL.Instance.CreateForCompanyEmployee(rList);
                ViewBag.fList = failedList;
                return View(rList);
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
        [Authorize(Roles = "CompanyHR")]
        public String CreateParticipant(Participant p)
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            int cmpId = loginHR.Company.CompanyId;
            
            p.CompanyName = loginHR.Company.CompanyName;
            p.Company = loginHR.Company;
            p.EmploymentStatus = "Employeed";
            p.OrganizationSize = loginHR.Company.OrganizationSize;
 
            List<Participant> newList = (List<Participant>)Session["ParticipantList"];
            if(newList != null && newList.Count != 0){
                foreach (Participant item in newList)
                {
                    if (item.IdNumber == p.IdNumber)
                    {
                        return null;
                    }
                }
            }
            if (ParticipantBLL.Instance.GetCmpParticipantByIdNumber(cmpId, p.IdNumber).Count == 0)
            {
                newList.Add(p);
                Session["ParticipantList"] = newList;
                
                Dictionary<string,string> dic = new Dictionary<string,string>();
                dic.Add("name", p.FullName);
                dic.Add("id", p.IdNumber);
                return JsonConvert.SerializeObject(dic);
            }
            else
            {
                return null;
            }
        }
        public class employee
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public void AddParticipants(string jsonstring)
        {
            employee[] participants = JsonConvert.DeserializeObject<employee[]>(jsonstring);
            List<Participant> list = new List<Participant>();
            if (participants.Length != 0)
            {
                Participant p;
                foreach (employee item in participants)
                {
                    p = null;
                    p = ParticipantBLL.Instance.GetParticipantByIdNumber(item.id);
                    if (p != null)
                    {
                        list.Add(p);
                    }
                }
            }
            Session["EmployeeList"] = list;
        }
        public ActionResult EditParticipant(string id)
        {
            List<Participant> list = (List<Participant>)Session["ParticipantList"];
            if (list.Count != 0 && list != null)
            {
                foreach (Participant item in list)
                {
                    if (item.IdNumber == id)
                    {
                        return PartialView(item);
                    }
                }
            }
            Participant p = ParticipantBLL.Instance.GetParticipantByIdNumber(id);
            if (p != null)
            {
                return PartialView(p);
            }
            else
            {
                return PartialView();
            }
            
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public string EditParticipant(Participant p)
        {
            List<Participant> list = (List<Participant>)Session["ParticipantList"];
            if (list.Count != 0 && list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].IdNumber == p.IdNumber)
                    {
                        list[i] = p;
                        Session["ParticipantList"] = list;
                        return p.IdNumber;
                    }
                }
            }
            List<Participant> list2 = (List<Participant>)Session["EmployeeList"];
            if(list2.Count!=0 && list2!=null){
                for(int j=0;j<list2.Count;j++){
                    if(list2[j].ParticipantId == p.ParticipantId)
                    {
                        list2[j] = p;
                        Session["EmployeeList"] = list2;
                        return p.IdNumber;
                    }
                }
            }
            return null;
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public void DeleteNewParticipant(string id)
        {
            List<Participant> list = (List<Participant>)Session["ParticipantList"];
            foreach (Participant p in list)
            {
                if (p.IdNumber == id)
                {
                    list.Remove(p);
                    Session["ParticipantList"] = list;
                    break;
                }
            }
        }
        [HttpPost]
        [Authorize(Roles = "CompanyHR")]
        public void DeleteOldParticipant(string id)
        {
            List<Participant> list = (List<Participant>)Session["EmployeeList"];
            foreach (Participant p in list)
            {
                if (p.IdNumber == id)
                {
                    list.Remove(p);
                    Session["EmployeeList"] = list;
                    break;
                }
            }
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