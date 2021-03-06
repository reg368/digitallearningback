﻿using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Game.Controllers
{
    public class ModelViewController : Controller
    {

        private QuestionService qservice = new QuestionService(); // 找 課程/關卡 題目

        // GET: Game/ModelView/QuestionDetail
        //答案選擇的畫面
        public ActionResult QuestionDetail(int qid)
        {
            Question question = qservice.selectByIdIncludeAnswer(qid);
            return View(question);
        }

        // GET: Game/ModelView/QuestionDetailInfo
        //選錯了 跳出正確答案訊息的畫面
        public ActionResult QuestionDetailInfo(int qid,int selectaid)
        {
            Question question = qservice.selectByIdIncludeAnswer(qid);
            ViewBag.selectaid = selectaid;
            return View(question);
        }
    }
}