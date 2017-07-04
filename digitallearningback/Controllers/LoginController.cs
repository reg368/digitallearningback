using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using digitallearningback.Models;
using digitallearningback.Models.DAO.Service;

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
        public ActionResult Login(InfoUser user) {

            if (ModelState.IsValid){

                InfoUser dbuser  = new InfoUserService().findByUserLoginId(user.login_id);

                if (dbuser != null && user.password.Equals(dbuser.password)){
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError(string.Empty, "帳號或密碼錯誤");
                    return View(user);
                }
            }
            else{
                return View(user);
            }

        }
    }
}