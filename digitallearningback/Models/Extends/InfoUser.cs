using digitallearningback.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class InfoUser
    {

        private LoginLogService logingService = new LoginLogService();

        private static readonly String infoUserkey = "infoUser";     //取得 存在 HttpSession 內  題目集合的 key

        //存入 HttpSession 登入user資訊
        public static void setLoginUser(InfoUser model)
        {
            HttpContext.Current.Session[infoUserkey] = model;
        }

        //取得 HttpSession 登入user資訊
        public static InfoUser getLoginUser()
        {
            return (InfoUser)HttpContext.Current.Session[infoUserkey];
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
    }
}