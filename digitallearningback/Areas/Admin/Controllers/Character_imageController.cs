using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class Character_imageController : Controller
    {
        private Character_imageService imageService = new Character_imageService();
        private Cimage_moodService moodService = new Cimage_moodService();
        private Cimage_professionService proService = new Cimage_professionService();
        private Dictionary<string, string> genderDict =  new Dictionary<string, string> { {"male","男" }, {"female","女" } };


        // GET: Character_image
        public ActionResult Index()
        {
            return View(imageService.selectAllInclude());
        }

        // GET: Character_image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = imageService.selectById(id);
            if (character_image == null)
            {
                return HttpNotFound();
            }
            return View(character_image);
        }

        // GET: Character_image/Create
        public ActionResult Create()
        {
            ViewBag.cimage_gander = new SelectList(this.genderDict, "key", "value");
            ViewBag.cimage_mood = new SelectList(moodService.getDbSet(), "cmood_id", "cmood_title");
            ViewBag.cimage_profession = new SelectList(proService.getDbSet(), "cprofession_id", "cprofession_title");
            return View();
        }

        // POST: Character_image/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "cimage_id,cimage_path,cimage_mood,cimage_gander,cimage_profession,cimage_joindate,image_level")] Character_image character_image,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile)
        {


            if (uploadFile == null || uploadFile.ContentLength == 0)
            {
                ModelState.AddModelError("imageUploadFile", "Image field is required");
            }
            else if (!UploadFileHelper.validImageTypes(uploadFile.ContentType))
            {
                ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg /png file");
            }

            if (ModelState.IsValid)
            {
       
                var path = UploadFileHelper.uploadFile(this, uploadFile, "Character_imageDir", "Character_imageUrl");

                character_image.cimage_path = path;
                character_image.cimage_joindate = DateTime.Today;

                imageService.insert(character_image);
                return RedirectToAction("Index");
            }

            ViewBag.cimage_mood = new SelectList(moodService.getDbSet(), "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(proService.getDbSet(), "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // GET: Character_image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = imageService.selectById(id);
            if (character_image == null)
            {
                return HttpNotFound();
            }

            ViewBag.cimage_gander = new SelectList(this.genderDict, "key", "value", character_image.cimage_gander);
            ViewBag.cimage_mood = new SelectList(moodService.getDbSet(), "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(proService.getDbSet(), "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // POST: Character_image/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "cimage_id,cimage_mood,cimage_gander,cimage_profession,image_level")] Character_image character_image,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile)
        {

            Character_image record = imageService.selectById(character_image.cimage_id);

            if (record == null) {
                return HttpNotFound();
            }

            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                if (UploadFileHelper.validImageTypes(uploadFile.ContentType))
                {
                    String image_path = UploadFileHelper.uploadFile(this, uploadFile, "Character_imageDir", "Character_imageUrl");
                    record.cimage_path = image_path;
                }
                else
                {
                    ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg /png file");
                }
            }


            if (ModelState.IsValid)
            {
                Debug.WriteLine("cimage_gander: " + character_image.cimage_gander);
                record.cimage_mood = character_image.cimage_mood;
                record.cimage_gander = character_image.cimage_gander;
                record.image_level = character_image.image_level;

                imageService.update(record);

                return RedirectToAction("Index");
            }
            ViewBag.cimage_mood = new SelectList(moodService.getDbSet(), "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(proService.getDbSet(), "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // GET: Character_image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = imageService.selectById(id);
            if (character_image == null)
            {
                return HttpNotFound();
            }
            return View(character_image);
        }

        // POST: Character_image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imageService.deleteByPrimaryKey(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                imageService.disposing();
                moodService.disposing();
                proService.disposing();
            }
            base.Dispose(disposing);
        }
    }
}