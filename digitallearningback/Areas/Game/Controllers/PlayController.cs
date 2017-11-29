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

        private Character_imageService chservice = new Character_imageService(); //找角色圖片
        private Question_groupService groupservice = new Question_groupService(); //找有哪些課程
        private Question_levelService levelservice = new Question_levelService(); //找課程關卡
        private QuestionService qservice = new QuestionService(); // 找 課程/關卡 題目
        private AnswerService answerervice = new AnswerService(); // 找 課程/關卡 題目
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
            else
            {
                return RedirectToAction("Login", "Login", new { area = "" });
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
                return View(level);
        }

        //開始找所有關卡內的題目
        public ActionResult LevelStart(int lid,int gid ,int passpoint)
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
                return RedirectToAction("Result", "Play");
            }
            //還有題目
            else
            {
                Question question = questions.PollFirst();
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

        public ActionResult Result()
        {
            return View();
        }

    }
}