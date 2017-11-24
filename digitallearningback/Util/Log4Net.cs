using digitallearningback.Models;
using System;
using System.Text;
using System.Web;

namespace digitallearningback.Util
{
    public class Log4Net 
    {
        private string loginglogDir = System.Configuration.ConfigurationManager.AppSettings["App_LoginLog"].ToString();

        private string logDir = System.Configuration.ConfigurationManager.AppSettings["App_DebugLog"].ToString();

        //Web.config 是否列印全域設定 on / off
        private string isPrint = System.Configuration.ConfigurationManager.AppSettings["Log4NetPrint"].ToString();

        private string className;

        public Log4Net(String className)
        {
            this.className = className;
        }

        //developer debug log
        public void debug(String title , String message)
        {

            if ("on".Equals(isPrint)) {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine("Class :" + this.className);
                sb.AppendLine(title + " : " + message);
                sb.AppendLine("=========================================================================");
                string filePath = logDir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath(filePath), sb.ToString());
            }
        }

        //user login log
        public void doLoginlog(InfoUser user,bool isLogingSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Class :" + this.className);
            sb.AppendLine("user login id  : " + user.login_id);
            sb.AppendLine("userpassword : " + user.password);
            sb.AppendLine("isLogingSuccess : " + (isLogingSuccess ? "true" : "false"));
            sb.AppendLine("=========================================================================");
            string filePath = loginglogDir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath(filePath), sb.ToString());
        }

    }
}