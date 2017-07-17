using System;
using System.ComponentModel.DataAnnotations;

namespace digitallearningback.DAO.Models
{
    public class InfoUser
    {
        public InfoUser() { }

        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
        public string character_image { get; set; }
        public string pet_image { get; set; }
        public string pet_name { get; set; }
        [Required]
        public string login_id { get; set; }
        [Required]
        public string password { get; set; }
        public Nullable<System.DateTime> joindate { get; set; }
        public string cimage_type { get; set; }
        public string pimage_type { get; set; }
        public int login_count { get; set; }
        public int group_id { get; set; }
        public string teacher_id { get; set; }
        public int money { get; set; }
        public int experience { get; set; }
        public int hp { get; set; }

        public enum VaildType
        {
            Teacher,
            Student
        };

        public Boolean validLogin(String password, VaildType type)
        {

            if (password.Equals(this.password))
            {
                switch (type)
                {
                    case VaildType.Teacher:
                        if (this.group_id == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case VaildType.Student:
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