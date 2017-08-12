using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace digitallearningback.Filter
{
    public class LogToFileAttribute : IExceptionFilter
    {

        private string logDir =  System.Configuration.ConfigurationManager.AppSettings["App_ExceptionLog"].ToString();

        public void OnException(ExceptionContext filterContext)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(filterContext.Exception.ToString());
            sb.AppendLine("=========================================================================");
            string filePath = logDir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath(filePath), sb.ToString());
        }
    }
}