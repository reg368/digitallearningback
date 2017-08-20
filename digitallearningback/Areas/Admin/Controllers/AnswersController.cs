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
    public class AnswersController : Controller
    {
        private Log4Net logger = new Log4Net("AnswersController");
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
        */
        
        // GET: Admin/Answers/Create
        public ActionResult Create(int qid , String qtext)
        {
            ViewBag.qid = qid;
            ViewBag.qtext = qtext;
            return View();
        }

        // POST: Admin/Answers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "qtext")] String qtext,
            [Bind(Include = "qid,text,is_correct")] Answer answer,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile)
        {

            if ((answer.text == null || answer.text.Length == 0)
                   && (uploadFile == null || uploadFile.ContentLength == 0))
            {
                ModelState.AddModelError("error", "請填寫選項文字或選項圖片");
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

                    var path = UploadFileHelper.uploadFile(uploadFile, "Answer_imageDir", "Answer_imageUrl");
                    answer.pic_path = path;
                }

                answer.joindate = DateTime.Today;

                answerservice.insert(answer);

                return RedirectToAction("Index", new { qid = answer.qid});
            }

            ViewBag.qid = answer.qid;
            ViewBag.qtext = qtext;

            return View(answer);
        }

        
        // GET: Admin/Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = answerservice.selectById(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Admin/Answers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "img_deleted")] String img_deleted,
            [Bind(Include = "uploadFile")]HttpPostedFileBase uploadFile,
            [Bind(Include = "id,qid,text,is_correct,pic_path")] Answer answer)
        {

            Answer record = answerservice.selectById(answer.id);

            if (record == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //如果沒填文字和上傳檔案
            if ((answer.text == null || answer.text.Length == 0)
                              && (uploadFile == null || uploadFile.ContentLength == 0))
            {

                //如果之前有上傳過圖檔 判斷是否有填舊圖存取動作
                if (record.pic_path != null)
                {
                    //有舊圖 但沒選取舊圖選取動作
                    if(img_deleted == null || "".Equals(img_deleted))
                    {
                        answer.pic_path = record.pic_path;
                        ModelState.AddModelError("error", "請填寫舊圖片存取動作");
                    //刪除舊圖片 但沒填文字 
                    } else if ("Y".Equals(img_deleted))
                    {
                        answer.pic_path = record.pic_path;
                        ModelState.AddModelError("error", "刪圖舊圖片時,請上傳新圖片或填寫選項文字");
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "請填寫選項文字或選項圖片");
                }
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
                    var path = UploadFileHelper.uploadFile(uploadFile, "Answer_imageDir", "Answer_imageUrl");
                    record.pic_path = path;
                }

                if ("Y".Equals(img_deleted))
                {
                    record.pic_path = null;
                }
                record.text = answer.text;
                record.is_correct = answer.is_correct;
                answerservice.update(record);

                return RedirectToAction("Index",new { qid = record.qid });
            }

            answer.Question = record.Question;
            return View(answer);
        }

        
        // GET: Admin/Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = answerservice.selectById(id);
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
            Answer record = answerservice.selectById(id);
            answerservice.deleteByPrimaryKey(id);

            return RedirectToAction("Index", new { qid = record.qid });
        }
        
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
