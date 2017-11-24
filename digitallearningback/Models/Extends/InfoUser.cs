using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class InfoUser
    {

        public static InfoUser getLoginUser()
        {
            return (InfoUser)HttpContext.Current.Session["infoUser"];
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