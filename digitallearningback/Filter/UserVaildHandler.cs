using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace digitallearningback.Filter
{
    public class UserVaildHandler : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FilterHelper.Log("OnActionExecuting", filterContext.RouteData, "UserVaildHandler");

            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipMyGlobalActionFilterAttribute), false).Any())
            {
                return;
            }

            if (filterContext.HttpContext.Session != null)
            {
                var infoUser = filterContext.HttpContext.Session["infoUser"];
                if (infoUser == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                                 new RouteValueDictionary {{ "Controller", "Login" },
                                                    { "Action", "Login" } });
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }
            }else {
                filterContext.Result = new RedirectToRouteResult(
                                 new RouteValueDictionary {{ "Controller", "LoginController" },
                                                    { "Action", "Login" } });
            }

        }
    }

    public class SkipMyGlobalActionFilterAttribute : Attribute
    {}
}