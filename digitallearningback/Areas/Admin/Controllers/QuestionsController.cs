using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class QuestionsController : Controller
    {
        private QuestionService questionservice = new QuestionService();

        // GET: Admin/Questions
        public ActionResult Index(int id,String groupname)
        {
            ViewBag.groupid = id;
            ViewBag.groupname = groupname;
            return View(questionservice.selectByGroupid(id));
        }

        /*
        // GET: Admin/Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        */
        /*
        // GET: Admin/Questions/Create
        public ActionResult Create()
        {
            ViewBag.groupid = new SelectList(db.Question_group, "id", "name");
            return View();
        }

        // POST: Admin/Questions/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,groupid,text,joindate,point,tip,pic_path,level_id,ismulti")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.groupid = new SelectList(db.Question_group, "id", "name", question.groupid);
            return View(question);
        }
        
        */
        /*
        // GET: Admin/Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupid = new SelectList(db.Question_group, "id", "name", question.groupid);
            return View(question);
        }

        // POST: Admin/Questions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupid,text,joindate,point,tip,pic_path,level_id,ismulti")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groupid = new SelectList(db.Question_group, "id", "name", question.groupid);
            return View(question);
        }

        // GET: Admin/Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Admin/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Question.Find(id);
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                questionservice.disposing();
            }
            base.Dispose(disposing);
        }
    }
}
