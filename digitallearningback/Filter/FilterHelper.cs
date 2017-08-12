using System;
using System.Diagnostics;
using System.Web.Routing;

namespace digitallearningback.Filter
{
    public class FilterHelper
    {
        public static void Log(string methodName, RouteData routeData,string filterName)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, filterName+" Log ");
        }
    }
}