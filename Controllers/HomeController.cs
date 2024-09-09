using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeRequest()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HeadOfDepartment()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employee()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MedicalOfficer()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MedicalOfficerDashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}