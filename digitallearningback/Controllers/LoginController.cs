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

            //重新嘗試登入後 就要刪掉原本儲存在session的資訊
            if (InfoUser.getLoginUser() != null || Question.getSessionListQuestions() != null)
            {
                InfoUser.cleanLoginUser();
                Question.cleanQuestions();
            }

            if (ModelState.IsValid){

                InfoUser dbuser  = userService.findByUserLoginId(user.login_id);

                if (dbuser != null && user != null &&  user.password != null && user.password.Equals(dbuser.password)){
                    return forward(dbuser.LoginRedirect(), dbuser, true);
                }
                else
                {
                    ViewBag.msg = "帳號密碼錯誤 , 請輸入學號再次登入 , 或至portal聯絡助教";
                    return forward(View(user), user, false);
                }
            }
            else{
                ViewBag.msg = "帳號密碼輸入不正確 , 請輸入學號再次登入 , 或至portal聯絡助教";
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
            logger.debug("LoginForLtLab", "userid: "+ userid+ " password : "+ password);

                //重新嘗試登入後 就要刪掉原本儲存在session的資訊
            if (InfoUser.getLoginUser() != null || Question.getSessionListQuestions() != null)
                {
                logger.debug("LoginForLtLab", "session InfoUser is not null clearn");
                    InfoUser.cleanLoginUser();
                    Question.cleanQuestions();
                }

                InfoUser dbuser = userService.findByUserLoginId(userid);

                if (dbuser != null &&  password != null && password.Equals(dbuser.password))
                {
                    logger.debug("LoginForLtLab", "user vaild");

                    return forward(dbuser.LoginRedirect(), dbuser, true);
                }
                else
                {
                    logger.debug("LoginForLtLab", "user invaild");
                    //紀錄每次登入請求資訊
                    //logger.doLoginlog(userid,password, false);
                    ViewBag.msg = "登入失敗 , 請輸入學號再次登入 , 或至portal聯絡助教";
                    return View();
                }

        }


        private ActionResult forward(ActionResult result,InfoUser user,bool isLogingSuccess)
        {
            //紀錄每次登入請求資訊
            //logger.doLoginlog(user, isLogingSuccess);

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