using System;
using System.Web.Mvc;
using digitallearningback.Filter;
using digitallearningback.Models;
using digitallearningback.DAO;
using digitallearningback.Util;

namespace digitallearningback.Controllers
{
    
    public class LoginController : Controller
    {
        private InfoUserService userService = new InfoUserService();
        private Log4Net logger = new Log4Net("LoginController");


        // GET: Login
        [SkipMyGlobalActionFilter]
        public ActionResult Login()
        {
            logger.debug("test", "test .log");
            return View();
        }

        // POST : check login
        [HttpPost]
        [SkipMyGlobalActionFilter]
        public ActionResult Login(InfoUser user) {

            if (ModelState.IsValid){

                InfoUser dbuser  = userService.findByUserLoginId(user.login_id);

                if (dbuser != null && dbuser.validLogined(user.password,InfoUser.VaildTypes.Teacher)){
                    Session["infoUser"] = dbuser;
                    return RedirectToAction("Index", "Home",new { area = "Admin" });
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService.disposing();
            }
            base.Dispose(disposing);
        }
    }
}