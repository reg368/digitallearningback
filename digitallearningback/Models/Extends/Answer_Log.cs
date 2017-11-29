using digitallearningback.DAO;
using digitallearningback.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Answer_Log
    {
        private Answer_LogService service = new Answer_LogService();

        //作答後的Log 紀錄
        public void doCheckAnswerLog(Answer answer)
        {
            InfoUser user = InfoUser.getLoginUser();
            Answer_Level_Log levelLog = Answer_Level_Log.getSessionAnswer_Level_Log();

            Answer_Log model = new Answer_Log();
            model.userid = user.id;  //使用者id
            model.loginid = user.login_count; //登入紀錄id
            model.gid = levelLog.gid; //課程id
            model.lid = levelLog.lid; //關卡id
            model.levelLogid = levelLog.id; //關卡紀錄id
            model.qid = answer.qid; //題目id
            model.aid = answer.id; //答案選項id
            model.iscorrect = answer.is_correct; //是否答對 0 : 錯 , 1 : 對
            model.createTime = DateTime.Now;
            
            //如果這題答對 總答題對數+1 
            if(answer.is_correct == 1)
            {
                levelLog.correctnumber = levelLog.correctnumber + 1;
            }

            //紀錄回答題數
            levelLog.answernumber = levelLog.answernumber + 1;
            Answer_Level_Log.setSessionAnswer_Level_Log(levelLog);
            //更新關卡紀錄
            levelLog.doUpdateLog();

            service.insert(model);
        }
    }
}