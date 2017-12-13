using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Question
    {

        private static readonly String questionskey = "questions";     //取得 存在 HttpSession 內  題目集合的 key

        //存入 HttpSession  題目集合 資訊
        public static void setSessionListQuestions(List<Question> list)
        {
            HttpContext.Current.Session[questionskey] = list;
        }

        //取得  HttpSession  題目集合 資訊
        public static List<Question> getSessionListQuestions()
        {
            return (List<Question>)HttpContext.Current.Session[questionskey];
        }

        //清除登入的資料
        public static void cleanQuestions()
        {
            HttpContext.Current.Session[questionskey] = null;
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