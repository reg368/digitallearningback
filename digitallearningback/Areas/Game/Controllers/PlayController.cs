using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace digitallearningback.Areas.Game.Controllers
{
    public class PlayController : Controller
    {
        private InfoUserService userservice = new InfoUserService(); //找有哪些其他玩家這一關過關了
        private Character_imageService chservice = new Character_imageService(); //找角色圖片
        private Question_groupService groupservice = new Question_groupService(); //找有哪些課程
        private Question_levelService levelservice = new Question_levelService(); //找課程關卡
        private QuestionService qservice = new QuestionService(); // 找 課程/關卡 題目
        private AnswerService answerervice = new AnswerService(); // 找 課程/關卡 題目
        private fun_CalculateAnswerConceptPoint_ResultService resultservice = new fun_CalculateAnswerConceptPoint_ResultService(); // 題目做完查概念權重結果

        private Log4Net logger = new Log4Net("PlayController");

        //課程選擇頁
        public ActionResult Index()
        {

            InfoUser user = InfoUser.getLoginUser();
            if (user != null)
            {

                Character_image character = chservice.selectById(user.character_image);
                Character_image pet = chservice.selectById(user.pet_image);

                ViewBag.charcterimage = character == null ? "" : character.cimage_path;
                ViewBag.petimage = pet == null ? "" : pet.cimage_path;

                List<Question_group> groups = groupservice.selectAll();
                ViewBag.groups = groups;
            }

            return View();
        }

        //課程關卡選擇頁
        [HttpPost]
        public ActionResult LevelSelect(int gid)
        {

            List<Question_level> grouplevels = levelservice.selectListByGroupid(gid);
            if (grouplevels != null && grouplevels.Count > 0)
            {
                Question_level level = grouplevels.FirstOrDefault();

                ViewBag.groupname = level.Question_group.name;
                ViewBag.levels = grouplevels;
                ViewBag.gid = gid;
                return View();
            }
            else
            {
                ViewBag.error = "此課程沒有任何關卡 , 請聯絡課程導師";
                return Index();
            }
        }


        //關卡開始
        public ActionResult Nextlevel(int lid)
        {
                Question_level level = levelservice.selectById(lid);
                ViewBag.gid = level.group_id;
                return View(level);
        }

        //開始找所有關卡內的題目
        public ActionResult LevelStart(int lid,int gid)
        {

            //如果要隨機出題的話 就打亂順序
            List<Question> questions = qservice.selectByGroupidAndLevelid(gid, lid);

            //將這次的題目存到HttpSession
            Question.setSessionListQuestions(questions);

            //關卡Log紀錄
            Answer_Level_Log.doLevelStartLog(questions, lid, gid);

            return RedirectToAction("GameOn", "Play");
        }


        //開始遊戲
        public ActionResult GameOn()
        {

            //從HttpSession取出題目
            List<Question> questions = Question.getSessionListQuestions();
        

            //關卡題目都做完了
            if (questions == null || questions.Count == 0)
            {
                //算出這一次作答的答題率 並且儲存
                Answer_Level_Log.getSessionAnswer_Level_Log().doFinishedLog();
                return RedirectToAction("Result", "Play");
            }
            //還有題目
            else
            {
                //從集合中取出第一個題目 且 集合中題目數-1
                Question question = questions.PollFirst();
                questions.Shuffle();

                //-1數量後的集合題目 塞回session
                Question.setSessionListQuestions(questions);
                
                //目前做到第幾題 
                ViewBag.currentQuestionIndex = Answer_Level_Log.getSessionAnswer_Level_Log().questionnumber - questions.Count;

                logger.debug("PollFirst questions size ", ":" + questions.Count);
                return View(question);

            }
        }

        //答題正不正確判斷 said : 使用者選的 答案id 
        public ActionResult CheckAnswer(string said)
        {

            int aid = Convert.ToInt32(said);

            Answer answer = answerervice.selectById(aid);

            //紀錄這次答題的狀況 並且如果答對的話更新關卡狀態
            new Answer_Log().doCheckAnswerLog(answer);

            var result = new
            {
                id = answer.id,
                qid = answer.qid,
                is_correct = answer.is_correct
            };

            return Json(result);
        }

        //呈現結果雷達圖的頁面
        public ActionResult Result()
        {
            ViewBag.levellogid = Answer_Level_Log.getSessionAnswer_Level_Log().id;
            Question_level level = levelservice.selectById(Answer_Level_Log.getSessionAnswer_Level_Log().lid);
            ViewBag.start = level.getCorrectPasspointStar((int)Answer_Level_Log.getSessionAnswer_Level_Log().passpoint);
            return View();
        }

        //呈現雷達圖的頁面 ajax call 回傳概念權重資料
        public ActionResult GetResultData(string logid)
        {
            int levellogid = Convert.ToInt32(logid);

            return Json(resultservice.selectByLevelLogId(levellogid));
        }

        public ActionResult SearchPassedLevelUser(int lid , String level , String gname)
        {
            ViewBag.level = level;
            ViewBag.gname = gname;
            return View(userservice.selectLevelPassedUser(lid));
        }

    }
}