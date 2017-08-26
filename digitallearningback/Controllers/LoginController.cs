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
                if (dbuser != null && user.password.Equals(dbuser.password)){

                    //如果登入帳號 是管理者或老師 則進入管理端
                    if ((dbuser.validLogined(user.password, InfoUser.UserRole.Teacher) ||
                             dbuser.validLogined(user.password, InfoUser.UserRole.Admin))
                        )
                    {
                        Session["infoUser"] = dbuser;
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    //如果是學生就 進入遊戲
                    else if ((dbuser.validLogined(user.password, InfoUser.UserRole.Student)))
                    {
                        Session["infoUser"] = dbuser;

                        //還沒有選擇遊戲角色 第一次登入 進入建立遊戲角色頁面
                        if (dbuser.character_image == null || "".Equals(dbuser.character_image))
                        {
                            return RedirectToAction("SelectGender", "Create", new { area = "Game" });
                        }
                        //已選擇遊戲角色 (第n次登入) 開始遊戲
                        else {
                            return RedirectToAction("Start", "Start", new { area = "Game" });
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "帳號或密碼錯誤");
                return View(user);

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