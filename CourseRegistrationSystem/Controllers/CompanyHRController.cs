using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseRegistration.Models;
using CourseRegistration.BLL;

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

        // GET: CompanyHR
        public ActionResult CompanyInfo()
        {

            Company company = CompanyBLL.Instance.GetCompanyById(1);

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

        // GET: CompanyHR
        public ActionResult EmployeeList()
        {
            Company company = CompanyBLL.Instance.GetCompanyById(1);
            List<Participant> participantList = ParticipantBLL.Instance.GetAllParticipantsByCompanyId(company.CompanyId);
            return View(participantList);
        }

        // GET: CompanyHR/Create
        public ActionResult CreateEmployee()
        {
            return View();
        }

        // POST: CompanyHR/Create
        [HttpPost]
        public ActionResult CreateEmployee(Participant participant)
        {
            try
            {
                Company company = CompanyBLL.Instance.GetCompanyById(1);
                ParticipantBLL.Instance.CreateForCompanyEmployee(company, participant);

                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }

    }
}
