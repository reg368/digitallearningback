using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Game.Controllers
{
    public class CreateController : Controller
    {
        private InfoUser infoUser = SessionHelper.getLoginUser();
        private InfoUserService uservice = new InfoUserService();
        private Character_imageService chservice = new Character_imageService();
        private Cimage_professionService cpservice = new Cimage_professionService();
        private Log4Net logger = new Log4Net("CreateController");

        // GET: Game/Create
        public ActionResult SelectGender()
        {
            return View(infoUser);
        }

        //選擇遊戲角色
        public ActionResult SelectCharacter(string gender,int pid)
        {
            var prolist = cpservice.selectListForSelectCharacter();
            if (pid == -1)
            {
                pid = prolist.FirstOrDefault().cprofession_id;
            }
            ViewBag.prolist = prolist;

            var characterlist = chservice.selectListByGenderAndPro(gender, pid);

            if (characterlist != null && characterlist.Count() > 0)
            {
                var imagepaths = characterlist.Aggregate
                        (
                            (i, j) => new Character_image
                            {
                                cimage_path = (i.cimage_path + "," + j.cimage_path)
                            }
                        ).cimage_path;


                ViewBag.imagepaths = imagepaths;
                ViewBag.gender = gender;

                //遊戲角色 : action SelectedPet 會取出來用 
                //SelectCharacter view 是選 List characterlist 的 index
                TempData["characterlist"] = characterlist;
            }

            return View();
        }

        //選擇遊戲寵物
        public ActionResult SelectedPet(int char_index)
        {
            //SelectCharacter view 是選 List characterlist 的 index
            var characterlist = TempData["characterlist"] as List<Character_image> ;

            if (characterlist != null && characterlist.Count() > 0)
            {
                //取得使用者選的遊戲角色 塞回session
                var selected = characterlist.ElementAt(char_index);
                infoUser.character_image = selected.cimage_id;
                Session["infoUser"] = infoUser;

                var petlist = chservice.selectListByProName("寵物");

                if (petlist != null && petlist.Count() > 0)
                {
                    var imagepaths = petlist.Aggregate
                       (
                           (i, j) => new Character_image
                           {
                               cimage_path = (i.cimage_path + "," + j.cimage_path)
                           }
                       ).cimage_path;

                    ViewBag.imagepaths = imagepaths;
                    TempData["petlist"] = petlist;
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }



        //編輯遊戲角色和寵物名稱
        public ActionResult EditChNameAndPetName(int char_index)
        {
            //SelectCharacter view 是選 List characterlist 的 index
            var petlist = TempData["petlist"] as List<Character_image>;

            if (petlist != null && petlist.Count() > 0)
            {
                //取得使用者選的遊戲角色 塞回session
                var selected = petlist.ElementAt(char_index);
                infoUser.pet_image = selected.cimage_id;
                Session["infoUser"] = infoUser;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(new EditCharNameViewMD());
        }

        //建立遊戲角色以及寵物
        public ActionResult Create(EditCharNameViewMD model)
        {
            if (ModelState.IsValid)
            {
                //更新infoUser 資訊
                infoUser.character_name = model.character_name;
                infoUser.pet_name = model.pet_name;
                uservice.update(infoUser);

                //塞回 seession
                Session["infoUser"] = infoUser;

                //開始遊戲
                return RedirectToAction("Index", "Play");
            }
            return View("EditChNameAndPetName", model);
        }

    }
}