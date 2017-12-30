using digitallearningback.DAO;
using digitallearningback.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Answer_Level_Log
    {
        private Log4Net logger = new Log4Net("Answer_Level_Log");
        private Answer_Level_LogService service = new Answer_Level_LogService();
        private static readonly String levelLogkey = "Answer_Level_Log";     //取得 存在 HttpSession 內  題目集合的 key

        //存入 HttpSession 當下遊戲關卡資訊
        public static void setSessionAnswer_Level_Log(Answer_Level_Log model)
        {
            HttpContext.Current.Session[levelLogkey] = model;
        }

        //取得存在 HttpSession  當下遊戲關卡資訊
        public static Answer_Level_Log getSessionAnswer_Level_Log()
        {
            return (Answer_Level_Log)HttpContext.Current.Session[levelLogkey];
        }

        //PlayController.cs  LevelStart關卡開始 的資料紀錄
        public static void doLevelStartLog(List<Question> questions , int lid , int gid)
        {
            InfoUser user = InfoUser.getLoginUser();
            Log4Net logger = new Log4Net("Answer_Level_Log");
            Answer_Level_Log model = new Answer_Level_Log();
            model.userid = user.id;
            model.loginid = user.login_count;
            model.lid = lid;
            model.gid = gid;

            //這次關卡的所有題目id
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < questions.Count(); i++)
            {
                if (i < (questions.Count() - 1))
                {
                    sb.Append(questions.ElementAt(i).id + ",");
                }
                else
                {
                    sb.Append(questions.ElementAt(i).id);
                }
            }
            model.qids = sb.ToString();
            model.isfinished = 0;  //是否做完關卡所有的題目 初始化 
            model.createTime = DateTime.Now;
            model.correctnumber = 0; //答對的題目數 初始化
            model.passpoint = 0;  //使用者這次做完關卡獲得的答對率(看可以得到幾個星星) 初始化
            model.questionnumber = questions.Count(); //總題目數 
            model.answernumber = 0;  //答對的題目數 初始化

            new Answer_Level_LogService().insert(model);

            HttpContext.Current.Session[levelLogkey] = model;

        }


        public void doFinishedLog()
        {
            if(this.correctnumber != 0 && this.questionnumber != 0)
            {
                this.passpoint = ((decimal)this.correctnumber / (decimal)this.questionnumber) * (decimal)100;
                this.isfinished = 1;
                setSessionAnswer_Level_Log(this);
                this.doUpdateLog();
            }
        }

        public void doUpdateLog()
        {
            service.update(this);
        }
    }
}