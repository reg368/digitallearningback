using System.Web;
using System.Web.Mvc;
using digitallearningback.Filter;

namespace digitallearningback
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UserVaildHandler());  //使用者登入的filter
        }
    }
}
