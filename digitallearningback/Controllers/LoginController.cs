using System;
using System.Web.Mvc;
using digitallearningback.Filter;
using digitallearningback.Models;
using digitallearningback.Models.DAO.Service;

namespace digitallearningback.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        [SkipMyGlobalActionFilter]
        public ActionResult Login()
        {
            return View();
        }

        // POST : check login
        [HttpPost]
        [SkipMyGlobalActionFilter]
        public ActionResult Login(InfoUser user) {

            if (ModelState.IsValid){

                InfoUser dbuser  = new InfoUserService().findByUserLoginId(user.login_id);

                if (dbuser != null && dbuser.validLogined(user.password,InfoUser.VaildTypes.Teacher)){
                    Session["infoUser"] = dbuser;
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