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
using digitallearningback.Util;

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
        
        // GET: Admin/Questions/Create
        public ActionResult Create(int id, String groupname)
        {
            ViewBag.groupid = id;
            ViewBag.groupname = groupname;
            return View();
        }

        // POST: Admin/Questions/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "groupname")] String groupname,
            [Bind(Include = "groupid,text,point,tip")] Question question,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile)
        {

            if ((question.text == null || question.text.Length == 0)
                    && (uploadFile == null || uploadFile.ContentLength == 0))
            {
                ModelState.AddModelError("error", "請填寫題目文字或題目圖片");
            }

            if ((uploadFile != null && uploadFile.ContentLength != 0) &&
                !UploadFileHelper.validImageTypes(uploadFile.ContentType))
            {
                ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg /png file");
            }

          

            if (ModelState.IsValid)
            {

                if (uploadFile != null && uploadFile.ContentLength != 0) {

                    var path = UploadFileHelper.uploadFile(uploadFile, "Question_imageDir", "Question_imageUrl");
                    question.pic_path = path;
                }

                question.joindate = DateTime.Today;

                questionservice.insert(question);

                return RedirectToAction("Index",new { id = question.groupid  , groupname  = groupname });
            }

            ViewBag.groupid = question.groupid;
            ViewBag.groupname = groupname;

            return View(question);
        }
        
        
        
        // GET: Admin/Questions/Edit/5
        public ActionResult Edit(int? id, String groupname)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = questionservice.selectById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupname = groupname;
            return View(question);
        }

        // POST: Admin/Questions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "groupname")] String groupname,
            [Bind(Include = "id,text,point,tip")] Question question,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile)
        {
            Question record = questionservice.selectById(question.id);

            if (record == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if ((question.text == null || question.text.Length == 0)
                   && (uploadFile == null || uploadFile.ContentLength == 0))
            {
                ModelState.AddModelError("error", "請填寫題目文字或題目圖片");
            }

            if ((uploadFile != null && uploadFile.ContentLength != 0) &&
                !UploadFileHelper.validImageTypes(uploadFile.ContentType))
            {
                ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg /png file");
            }


            if (ModelState.IsValid)
            {

                if (uploadFile != null && uploadFile.ContentLength != 0)
                {
                    var path = UploadFileHelper.uploadFile(uploadFile, "Question_imageDir", "Question_imageUrl");
                    record.pic_path = path;
                }

                record.text = question.text;
                record.point = question.point;
                record.tip = question.tip;

                questionservice.update(record);

                return RedirectToAction("Index", new { id = record.groupid , groupname = groupname });
            }


            ViewBag.groupid = question.groupid;
            ViewBag.groupname = groupname;

            return View(question);
        }

        /*
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
