using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class InfoUser
    {
        public enum VaildTypes
        {
            Teacher,
            Student
        };

        public Boolean validLogined(String password, VaildTypes type)
        {

            if (password.Equals(this.password))
            {
                switch (type)
                {
                    case VaildTypes.Teacher:
                        if (this.group_id == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case VaildTypes.Student:
                        if (this.group_id == 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    default:
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