using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Game.Controllers
{
    public class PlayController : Controller
    {

        private Character_imageService chservice = new Character_imageService(); //找角色圖片
        private Question_groupService groupservice = new Question_groupService(); //找有哪些課程
        private Question_levelService levelservice = new Question_levelService(); //找課程關卡
        private QuestionService qservice = new QuestionService(); // 找 課程/關卡 題目
        private Log4Net logger = new Log4Net("PlayController");

        private readonly String grouplevelkey = "grouplevels";  //取得 存在 HttpSession 內  關卡集合的 key
        private readonly String questionskey = "questions";     //取得 存在 HttpSession 內  題目集合的 key

        //課程選擇頁
        public ActionResult Index()
        {

            InfoUser user = SessionHelper.getLoginUser();
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

        //課程關卡查詢
        [HttpPost]
        public ActionResult GroupSelect(int gid)
        {

            List<Question_level> grouplevels = levelservice.selectListByGroupid(gid);
            if(grouplevels != null && grouplevels.Count > 0)
            {
                Session[grouplevelkey] = grouplevels;

                return RedirectToAction("NextLevel", "Play");
            }
            else
            {
                ViewBag.error = "此課程沒有任何關卡 , 請聯絡課程導師";
                return Index();
            }
        }

        //下一關卡
        public ActionResult Nextlevel()
        {

           List<Question_level> grouplevels = Session[grouplevelkey] as List<Question_level>;

            //結束了 所有關卡做完
            if (grouplevels == null || grouplevels.Count == 0)
            {
                return null;
            }
            else
            {
                Question_level level = new Question_level();
                level = grouplevels.PollFirst<Question_level>();
                Session[grouplevelkey] = grouplevels;
                return View(level);
            }

        }

        //開始找所有關卡內的題目
        public ActionResult LevelStart(int lid)
        {

            Question_level level = levelservice.selectById(lid);



            //如果要隨機出題的話 就打亂順序
            List<Question> questions = qservice.selectByGroupidAndLevelid(level.group_id, level.id);

            logger.debug("after search quesitons count ", "after search  questions.Count : " + questions.Count);

            if (level.israndom == 1)
            {
                questions.Shuffle();
            }

            logger.debug("quesitons count ", " questions.Count : " + questions.Count);

            Session[questionskey] = questions;


            return RedirectToAction("GameOn", "Play");
        }


        //開始遊戲
        public ActionResult GameOn()
        {

            List<Question> questions = Session[questionskey] as List<Question>;

            logger.debug("Session quesitons count ", "Session questions.Count : " + questions.Count);

            //這一關題目都做完了
            if (questions == null || questions.Count == 0)
            {
                return RedirectToAction("Nextlevel", "Play");
            }
            //還有題目
            else
            {
                Question question = questions.PollFirst();
                return View(question);

            }
        }

    }
}