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
            filters.Add(new UserVaildHandler());   //使用者登入的filter
            filters.Add(new LogOutputAttribute()); //所有例外的 Log out put (印在console , 僅適合開發階段使用)
            filters.Add(new LogToFileAttribute()); //所有例外的 Log out put (印在 .txt 文字檔 , 適合部屬階段使用)
        }
    }
}
