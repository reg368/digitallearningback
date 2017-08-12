using System.Web.Mvc;

namespace digitallearningback.Filter
{
    public class LogOutputAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            FilterHelper.Log("OnActionExecuted", filterContext.RouteData, "LogOutputAttribute");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FilterHelper.Log("OnActionExecuting", filterContext.RouteData, "LogOutputAttribute");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            FilterHelper.Log("OnResultExecuted", filterContext.RouteData, "LogOutputAttribute");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            FilterHelper.Log("OnResultExecuting", filterContext.RouteData, "LogOutputAttribute");
        }
    }
}