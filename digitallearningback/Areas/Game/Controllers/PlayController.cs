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

        // GET: Game/Play
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
    }
}