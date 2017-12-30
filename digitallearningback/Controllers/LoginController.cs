using System;
using System.Web.Mvc;
using digitallearningback.Filter;
using digitallearningback.Models;
using digitallearningback.DAO;
using digitallearningback.Util;
using System.Net;

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
            if (InfoUser.getLoginUser() != null && Question.getSessionListQuestions() != null && Question.getSessionListQuestions().Count > 0)
            {
                return RedirectToAction("LoginBlock", "Login", new { area = "" });
            }
            else if (InfoUser.getLoginUser() != null)
            {
                return InfoUser.getLoginUser().LoginRedirect();
            }
            else
            {
                return View();
            }
        }

        //遊戲進行到一半異常中斷 就會阻止二次登入
        //如果 HttpSession InfoUser & Question 都有資料就會進入這個畫面
        //要求使用者登出
        [SkipMyGlobalActionFilter]
        public ActionResult LoginBlock()
        {
            return View();
        }

        //登出 刪掉 InfoUser & Question 存在 HTTPsession 的資料 
        [SkipMyGlobalActionFilter]
        public ActionResult LoginOut()
        {
            InfoUser.cleanLoginUser();
            Question.cleanQuestions();

            return RedirectToAction("Login", "Login", new { area = "" });
        }

        // POST : check login
        [HttpPost]
        [SkipMyGlobalActionFilter]
        public ActionResult Login(InfoUser user) {

            if (ModelState.IsValid){

                InfoUser dbuser  = userService.findByUserLoginId(user.login_id);

                if (dbuser != null && user.password.Equals(dbuser.password)){
                    return forward(dbuser.LoginRedirect(), dbuser, true);
                }
                else
                {
                    return forward(View(user), user, false);
                }
            }
            else{
                return View(user);
            }

        }

        /*[SkipMyGlobalActionFilter]
        public ActionResult LoginForLtLab()
        {
            return View();
        }*/

        // POST : for LtLab Entery view access
        [HttpPost]
        [SkipMyGlobalActionFilter]
        public ActionResult LoginForLtLab(String userid , String password)
        {

            InfoUser dbuser = userService.findByUserLoginId(userid);

            if (dbuser != null && password.Equals(dbuser.password))
            {
                return forward(dbuser.LoginRedirect(), dbuser, true);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        private ActionResult forward(ActionResult result,InfoUser user,bool isLogingSuccess)
        {
            //紀錄每次登入請求資訊
            logger.doLoginlog(user, isLogingSuccess);

            if (isLogingSuccess)
            {

                //登入成功 紀錄寫到DB
                user.doLoginLog();

                //logger.debug("login_count id", user.login_count+"");
                InfoUser.setLoginUser(user);

            }
            return result;
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