﻿using System;
using System.Text;
using System.Web;

namespace digitallearningback.Util
{
    public class Log4Net 
    {
        private string logDir = System.Configuration.ConfigurationManager.AppSettings["App_DebugLog"].ToString();
        
        //Web.config 是否列印全域設定 on / off
        private string isPrint = System.Configuration.ConfigurationManager.AppSettings["Log4NetPrint"].ToString();

        private string className;

        public Log4Net(String className) {
            this.className = className;
        }

        public void debug(String title , String message) {

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

    }
}