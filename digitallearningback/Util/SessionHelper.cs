using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using digitallearningback.Models;

namespace digitallearningback.Util
{
    public class SessionHelper
    {
        public static InfoUser getLoginUser() {
            return (InfoUser) HttpContext.Current.Session["infoUser"];
        }
    }
}