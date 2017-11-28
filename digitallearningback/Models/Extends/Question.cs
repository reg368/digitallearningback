using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Question
    {

        private static readonly String questionskey = "questions";     //取得 存在 HttpSession 內  題目集合的 key

        public static void setSessionListQuestions(List<Question> list)
        {
            HttpContext.Current.Session[questionskey] = list;
        }

        public static List<Question> getSessionListQuestions()
        {
            return (List<Question>)HttpContext.Current.Session[questionskey];
        }

        public String  minimalText() {

            if (this.text != null && this.text.Length > 20)
            {
                return this.text.Substring(0, 20) + "...";
            }
            else
            {
                return this.text;
            }
        }
    }
}