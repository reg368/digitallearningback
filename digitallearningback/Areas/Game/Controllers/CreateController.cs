using System.Linq;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Game.Controllers
{
    public class CreateController : Controller
    {
        private InfoUser infoUser = SessionHelper.getLoginUser();
        private Character_imageService chservice = new Character_imageService();
        private Cimage_professionService cpservice = new Cimage_professionService();
        private Log4Net logger = new Log4Net("CreateController");

        // GET: Game/Create
        public ActionResult SelectGender()
        {
            return View(infoUser);
        }

        public ActionResult SelectCharacter(string gender,int pid)
        {

            logger.debug("SelectCharacter ", "SelectCharacter action");

            var prolist = cpservice.selectListForSelectCharacter();
            if (pid == -1)
            {
                pid = prolist.FirstOrDefault().cprofession_id;
            }
            ViewBag.prolist = prolist;

            var select_character = chservice.selectListByGenderAndPro(gender, pid);

            if (select_character != null && select_character.Count() > 0)
            {
                var imagepaths = select_character.Aggregate
                        (
                            (i, j) => new Character_image
                            {
                                cimage_path = (i.cimage_path + "," + j.cimage_path)
                            }
                        ).cimage_path;

                logger.debug("images path : ", imagepaths);

                ViewBag.imagepaths = imagepaths;
                ViewBag.gender = gender;

                TempData["select_character"] = select_character;
            }
            else {
                logger.debug("select_character path : ", "select_character is null");
            }
            return View();
        }

    }
}