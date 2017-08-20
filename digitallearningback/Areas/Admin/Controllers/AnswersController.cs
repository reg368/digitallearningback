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
    public class AnswersController : Controller
    {

        private QuestionService questionservice = new QuestionService();
        private AnswerService answerservice = new AnswerService();

        // GET: Admin/Answers
        public ActionResult Index(int? qid)
        {
            if (qid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(questionservice.selectById(qid));
            }

        }

        /*
        // GET: Admin/Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        
        // GET: Admin/Answers/Create
        public ActionResult Create()
        {
            ViewBag.qid = new SelectList(db.Question, "id", "text");
            return View();
        }

        // POST: Admin/Answers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,qid,text,is_correct,joindate,pic_path")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.qid = new SelectList(db.Question, "id", "text", answer.qid);
            return View(answer);
        }

        // GET: Admin/Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.qid = new SelectList(db.Question, "id", "text", answer.qid);
            return View(answer);
        }

        // POST: Admin/Answers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,qid,text,is_correct,joindate,pic_path")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.qid = new SelectList(db.Question, "id", "text", answer.qid);
            return View(answer);
        }

        // GET: Admin/Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Admin/Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answer.Find(id);
            db.Answer.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                answerservice.disposing();
            }
            base.Dispose(disposing);
        }
    }
}
