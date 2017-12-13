using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class LoginLog
    {
        private static readonly String loginLogIdkey = "loginLogIdkey";     //取得 存在 Cookie 內  登入記錄的編號

        //存入 HttpSession 登入user資訊
        public static void setLoginLogId(int? logindid)
        {
            HttpContext.Current.Response.Cookies[loginLogIdkey].Value = "-" + logindid;
        }
            //取得 HttpSession 登入user資訊
        public static string getLoginLogId()
        {
            return "hi";
            //return HttpContext.Current.Response.Cookies[loginLogIdkey].Value.ToString();
        }
    }
}