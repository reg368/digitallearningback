using digitallearningback.Models;
using digitallearningback.Util;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace digitallearningback.Filter
{
    public class UserVaildHandler : ActionFilterAttribute
    {

        private Log4Net logger = new Log4Net("UserVaildHandler");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipMyGlobalActionFilterAttribute), false).Any())
            {
                return;
            }
            else
            {
                var infoUser = new InfoUser().getLoginUser(filterContext);

                if (infoUser == null)
                {

                    filterContext.Result = new RedirectToRouteResult(
                                    new RouteValueDictionary(
                                            new
                                            {
                                                action = "Login",
                                                controller = "Login",
                                                area = ""
                                            }
                                        ));
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }
            }
        }
    }

    public class SkipMyGlobalActionFilterAttribute : Attribute
    {}
}