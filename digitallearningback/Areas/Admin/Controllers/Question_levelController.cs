using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digitallearningback.Models;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class Question_levelController : Controller
    {
        private yzucsEntities db = new yzucsEntities();

        // GET: Admin/Question_level
        public ActionResult Index()
        {
            var question_level = db.Question_level.Include(q => q.Question_group);
            return View(question_level.ToList());
        }

        // GET: Admin/Question_level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_level question_level = db.Question_level.Find(id);
            if (question_level == null)
            {
                return HttpNotFound();
            }
            return View(question_level);
        }

        // GET: Admin/Question_level/Create
        public ActionResult Create()
        {
            ViewBag.group_id = new SelectList(db.Question_group, "id", "name");
            return View();
        }

        // POST: Admin/Question_level/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,level,joindate,group_id,isvisible,israndom,totalqnumber,correctqnumber,awardmoney,awardexperience,fromquestion,toquestion")] Question_level question_level)
        {
            if (ModelState.IsValid)
            {
                db.Question_level.Add(question_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.group_id = new SelectList(db.Question_group, "id", "name", question_level.group_id);
            return View(question_level);
        }

        // GET: Admin/Question_level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_level question_level = db.Question_level.Find(id);
            if (question_level == null)
            {
                return HttpNotFound();
            }
            ViewBag.group_id = new SelectList(db.Question_group, "id", "name", question_level.group_id);
            return View(question_level);
        }

        // POST: Admin/Question_level/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,level,joindate,group_id,isvisible,israndom,totalqnumber,correctqnumber,awardmoney,awardexperience,fromquestion,toquestion")] Question_level question_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.group_id = new SelectList(db.Question_group, "id", "name", question_level.group_id);
            return View(question_level);
        }

        // GET: Admin/Question_level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_level question_level = db.Question_level.Find(id);
            if (question_level == null)
            {
                return HttpNotFound();
            }
            return View(question_level);
        }

        // POST: Admin/Question_level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question_level question_level = db.Question_level.Find(id);
            db.Question_level.Remove(question_level);
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
