using System;
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
        private Question_groupService groupservice = new Question_groupService();
        private QuestionService questionservice = new QuestionService();

        // GET: Admin/Questions
        public ActionResult Index(int id)
        {
            return View(groupservice.selectById(id));
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

                return RedirectToAction("Index",new { id = question.groupid});
            }

            ViewBag.groupid = question.groupid;
            ViewBag.groupname = groupname;

            return View(question);
        }
        
        
        
        // GET: Admin/Questions/Edit/5
        public ActionResult Edit(int? id)
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
            
            return View(question);
        }

        // POST: Admin/Questions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "img_deleted")] String img_deleted,
            [Bind(Include = "id,groupid,text,point,tip")] Question question,
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
                //如果之前有上傳過圖檔 判斷是否有填舊圖存取動作
                if (record.pic_path != null)
                {
                    //有舊圖 但沒選取舊圖選取動作
                    if (img_deleted == null || "".Equals(img_deleted))
                    {
                        question.pic_path = record.pic_path;
                        ModelState.AddModelError("error", "請填寫舊圖片存取動作");
                        //刪除舊圖片 但沒填文字 
                    }
                    else if ("Y".Equals(img_deleted))
                    {
                        question.pic_path = record.pic_path;
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
                    var path = UploadFileHelper.uploadFile(uploadFile, "Question_imageDir", "Question_imageUrl");
                    record.pic_path = path;
                }

                if ("Y".Equals(img_deleted))
                {
                    record.pic_path = null;
                }

                record.text = question.text;
                record.point = question.point;
                record.tip = question.tip;

                questionservice.update(record);

                return RedirectToAction("Index", new { id = record.groupid});
            }

            question.Question_group = record.Question_group;
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
