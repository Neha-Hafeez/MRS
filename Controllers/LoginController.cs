using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.BLL;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult ValidateLogin(string username, string password)
        {
            BL_Login bl_login = new BL_Login();
            int roleId = bl_login.ValidateLogin(username, password);

            if (roleId > 0)
            {
                // Redirect to dashboard based on role
                switch (roleId)
                {
                    case 1: // MO
                        return Json(new { success = true, redirectUrl = "/Home/MedicalOfficerDashboard" });
                    case 2: // HOD
                        return Json(new { success = true, redirectUrl = "/Home/HeadOfDepartment" });
                    case 3: // Employee
                        return Json(new { success = true, redirectUrl = "/Home/Employee" });
                    case 4: // Registrar
                        return Json(new { success = true, redirectUrl = "/Home/Registrar" });
                    case 5: // Finance
                        return Json(new { success = true, redirectUrl = "/Home/Finance" });
                    default:
                        return Json(new { success = false, message = "Invalid username or password" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid username or password" });
            }
        }
    }
}