using digitallearningback.DAO;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace digitallearningback.Models
{
    public partial class InfoUser
    {

        private LoginLogService logingService = new LoginLogService();

        //private static readonly String loginLogIdkey = "loginLogIdkey";     //取得 存在 Cookie 內  登入記錄的編號
        private static readonly String infoUserkey = "infoUser";     //取得 存在 HttpSession 內  題目集合的 key

        //存入 HttpSession 登入user資訊
        public static void setLoginUser(InfoUser user)
        {
            //HttpContext.Current.Response.Cookies[loginLogIdkey].Value = "-" + this.login_count;
            HttpContext.Current.Session[infoUserkey] = user;
        }

        //取得 HttpSession 登入user資訊
        public static InfoUser getLoginUser()
        {
            //string login_count = HttpContext.Current.Request.Cookies[loginLogIdkey].Value.ToString();
            return (InfoUser)HttpContext.Current.Session[infoUserkey];
        }

        //filterContext 取得資訊
        public static InfoUser getLoginUser(ActionExecutingContext context)
        {
            //string login_count = context.HttpContext.Request.Cookies[loginLogIdkey].Value.ToString();
            return (InfoUser)context.HttpContext.Session[infoUserkey];
        }

        //清除登入的資料
        public static void cleanLoginUser()
        {
            HttpContext.Current.Session[infoUserkey] = null;
        }

        //LoginController.cs 紀錄登入log
        public void doLoginLog()
        {
            int logid = logingService.doLog(this);
            this.login_count = logid;
        }

        public UserRole role { get; set; }

        public enum UserRole
        {
            Admin,
            Teacher,
            Student,
            Test_student,
            None
        };

        public Boolean validLogined(String password, UserRole role)
        {

            if (password.Equals(this.password))
            {
                switch (role)
                {
                    case UserRole.Admin:
                        if (this.group_id == 1)
                        {
                            this.role = UserRole.Admin;
                            return true;
                        }
                        else
                        {
                            this.role = UserRole.None;
                            return false;
                        }
                    case UserRole.Teacher:
                        if (this.group_id == 2)
                        {
                            this.role = UserRole.Teacher;
                            return true;
                        }
                        else
                        {
                            this.role = UserRole.None;
                            return false;
                        }
                    case UserRole.Student:
                        if (this.group_id == 3)
                        {
                            this.role = UserRole.Student;
                            return true;
                        }
                        else
                        {
                            this.role = UserRole.None;
                            return false;
                        }
                    case UserRole.Test_student:
                        if (this.group_id == 4)
                        {
                            this.role = UserRole.Test_student;
                            return true;
                        }
                        else
                        {
                            this.role = UserRole.None;
                            return false;
                        }
                    default:
                        this.role = UserRole.None;
                        return false;
                }
            }
            else
            {
                return false;
            }
        }


        public ActionResult LoginRedirect()
        {
            //如果登入帳號 是管理者或老師 則進入管理端
            if (validLogined(this.password, InfoUser.UserRole.Teacher) || validLogined(this.password, InfoUser.UserRole.Admin))
            {
                return new   RedirectToRouteResult(
                                    new RouteValueDictionary(
                                            new
                                            {
                                                action = "Index",
                                                controller = "Home",
                                                area = "Admin"
                                            }
                                        ));
            }
            //如果是學生就 進入遊戲
            else if (validLogined(this.password, InfoUser.UserRole.Student) ||
                     validLogined(this.password, InfoUser.UserRole.Test_student))
            {
                //還沒有選擇遊戲角色 第一次登入 進入建立遊戲角色頁面
                if (this.character_image == null || "".Equals(this.character_image))
                {
                  
                    return  new RedirectToRouteResult(
                                    new RouteValueDictionary(
                                            new
                                            {
                                                action = "SelectGender",
                                                controller = "Create",
                                                area = "Game"
                                            }
                                        ));
                }
                //已選擇遊戲角色 (第n次登入) 開始遊戲
                else
                {
                    return new RedirectToRouteResult(
                                   new RouteValueDictionary(
                                           new
                                           {
                                               action = "Index",
                                               controller = "Play",
                                               area = "Game"
                                           }
                                       ));
                }
            }
            //不是任何角色 , 回登入頁
            else
            {
                cleanLoginUser();
                Question.cleanQuestions();
                return new RedirectToRouteResult(
                                  new RouteValueDictionary(
                                          new
                                          {
                                              action = "Login",
                                              controller = "Login",
                                              area = ""
                                          }
                                      ));
            }
        }
    }
}