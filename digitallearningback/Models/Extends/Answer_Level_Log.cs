using digitallearningback.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Answer_Level_Log
    {

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
        public static void doLevelStartLog(List<Question> questions , int lid , int gid , int passpoint)
        {
            Answer_Level_Log model = new Answer_Level_Log();
            model.userid = InfoUser.getLoginUser().id;
            model.loginid = InfoUser.getLoginUser().login_count;
            model.lid = lid;
            model.gid = gid;
            //這次關卡的所有題目id
            model.qids = questions.Aggregate
                         (
                             (i, j) => new Question
                             {
                                 text = (i.id + "," + j.id)
                             }
                         ).text;
            model.createTime = DateTime.Now;
            model.passpoint = passpoint;

            new Answer_Level_LogService().insert(model);

            HttpContext.Current.Session[levelLogkey] = model;

        }
    }
}