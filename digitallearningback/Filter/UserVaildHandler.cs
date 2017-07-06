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
            Log("OnActionExecuting", filterContext.RouteData);

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

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }

    }

    public class SkipMyGlobalActionFilterAttribute : Attribute
    {

    }
}