using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using digitallearningback.Models;

namespace digitallearningback.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST : check login
        [HttpPost]
        public ActionResult Login(User user) {

            if (ModelState.IsValid){
                return RedirectToAction("Index", "Home");
            }
            else{
                ModelState.AddModelError(string.Empty, "Student Name already exists.");
                return View(user);
            }

        }
    }
}