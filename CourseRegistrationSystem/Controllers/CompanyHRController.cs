using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;
using Microsoft.AspNet.Identity;

namespace CourseRegistrationSystem.Controllers
{
    public class CompanyHRController : Controller
    {
        // GET: CompanyHR
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyHR/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyHR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyHR/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyHR/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyHR/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyHR/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyHR/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region Company Functions

        // GET: CompanyHR
        public ActionResult CompanyInfo()
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            Company company = loginHR.Company;

            return View(company);
        }

        // POST: CompanyHR/CompanyInfo/5
        [HttpPost]
        public ActionResult CompanyInfo(Company company)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("CompanyInfo");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Employee Functions

        // GET: CompanyHR/EmployeeList
        public ActionResult EmployeeList()
        {
            String loginUserId = User.Identity.GetUserId();
            CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
            List<Participant> participantList = loginHR.Company.Employees;
            return View(participantList);
        }

        // GET: CompanyHR/EmployeeDetails/5
        public ActionResult EmployeeDetails(int id)
        {
            Participant participant = ParticipantBLL.Instance.GetParticipantById(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: CompanyHR/EmployeeCreate
        [Authorize(Roles = "CompanyHR")]
        public ActionResult EmployeeCreate()
        {
            return View();
        }

        // POST: CompanyHR/EmployeeCreate
        [HttpPost]
        public ActionResult EmployeeCreate(Participant participant)
        {
            try
            {
                String loginUserId = User.Identity.GetUserId();
                CompanyHR loginHR = CompanyHRBLL.Instance.GetCompanyHRByUserId(loginUserId);
                ParticipantBLL.Instance.CreateForCompanyEmployee(loginHR.Company, participant);

                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyHR/EmployeeEdit/5
        public ActionResult EmployeeEdit(int id)
        {
            Participant participant = ParticipantBLL.Instance.GetParticipantById(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: CompanyHR/EmployeeEdit/5
        [HttpPost]
        public ActionResult EmployeeEdit(int id, FormCollection collection)
        {
            try
            {
                Participant participant = ParticipantBLL.Instance.GetParticipantById(id);
                UpdateModel(participant);
                ParticipantBLL.Instance.EditParticipant(participant);

                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyHR/EmployeeDelete/5
        public ActionResult EmployeeDelete(int id)
        {
            Participant participant = ParticipantBLL.Instance.GetParticipantById(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: CompanyHR/EmployeeDelete/5
        [HttpPost]
        public ActionResult EmployeeDelete(int id, FormCollection collection)
        {
            try
            {
                Participant participant = ParticipantBLL.Instance.GetParticipantById(id);
                UpdateModel(participant);
                ParticipantBLL.Instance.DeleteParticipant(participant);

                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Registration Functions

        #endregion
    }
}
