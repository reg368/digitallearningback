using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digitallearningback.Models;

namespace digitallearningback.Controllers
{
    public class Character_imageController : Controller
    {
        private yzucsEntities db = new yzucsEntities();

        // GET: Character_image
        public ActionResult Index()
        {
            var character_image = db.Character_image.Include(c => c.Cimage_mood1).Include(c => c.Cimage_profession1);
            return View(character_image.ToList());
        }

        // GET: Character_image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = db.Character_image.Find(id);
            if (character_image == null)
            {
                return HttpNotFound();
            }
            return View(character_image);
        }

        // GET: Character_image/Create
        public ActionResult Create()
        {
            ViewBag.cimage_mood = new SelectList(db.Cimage_mood, "cmood_id", "cmood_title");
            ViewBag.cimage_profession = new SelectList(db.Cimage_profession, "cprofession_id", "cprofession_title");
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

            var validImageTypes = new string[] { "image/jpg", "image/jpeg", "image/png" };

            if (uploadFile == null || uploadFile.ContentLength == 0)
            {
                ModelState.AddModelError("imageUploadFile", "Image field is required");
            }
            else if (!validImageTypes.Any(t => t.Equals(uploadFile.ContentType)))
            {
                ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg /png file");
            }

            InfoUser user = (InfoUser)Session["infoUser"];

            if (ModelState.IsValid && user != null )
            {
                var uploadDir = "~/Images/Character_image";

                //String fileId = Guid.NewGuid().ToString().Replace("-", "");
                
                var imagePath = Path.Combine(Server.MapPath(uploadDir), uploadFile.FileName);
                uploadFile.SaveAs(imagePath);

                character_image.cimage_path = "/Images/Character_image/"+ uploadFile.FileName;

                db.Character_image.Add(character_image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cimage_mood = new SelectList(db.Cimage_mood, "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(db.Cimage_profession, "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // GET: Character_image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = db.Character_image.Find(id);
            if (character_image == null)
            {
                return HttpNotFound();
            }
            ViewBag.cimage_mood = new SelectList(db.Cimage_mood, "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(db.Cimage_profession, "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // POST: Character_image/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cimage_id,cimage_path,cimage_mood,cimage_gander,cimage_profession,cimage_joindate,image_level")] Character_image character_image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character_image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cimage_mood = new SelectList(db.Cimage_mood, "cmood_id", "cmood_title", character_image.cimage_mood);
            ViewBag.cimage_profession = new SelectList(db.Cimage_profession, "cprofession_id", "cprofession_title", character_image.cimage_profession);
            return View(character_image);
        }

        // GET: Character_image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character_image character_image = db.Character_image.Find(id);
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
            Character_image character_image = db.Character_image.Find(id);
            db.Character_image.Remove(character_image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
