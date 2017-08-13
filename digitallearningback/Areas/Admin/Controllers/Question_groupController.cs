using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class Question_groupController : Controller
    {
        private Question_groupService gropuService = new Question_groupService();
        private InfoUser user = SessionHelper.getLoginUser();

        // GET: Admin/Question_group
        public ActionResult Index()
        {
            return View(gropuService.selectListByUserid(user.id));
        }

        // GET: Admin/Question_group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_group question_group = gropuService.selectById(id);
            if (question_group == null)
            {
                return HttpNotFound();
            }
            return View(question_group);
        }

        // GET: Admin/Question_group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Question_group/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,number,semester")] Question_group question_group)
        {
            if (ModelState.IsValid)
            {
                question_group.userid = user.id;
                question_group.joindate = DateTime.Today;

                gropuService.insert(question_group);
                return RedirectToAction("Index");
            }

            return View(question_group);
        }

        // GET: Admin/Question_group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_group question_group = gropuService.selectById(id);
            if (question_group == null)
            {
                return HttpNotFound();
            }
            return View(question_group);
        }

        // POST: Admin/Question_group/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,number,semester")] Question_group question_group)
        {

            Question_group record = gropuService.selectById(question_group.id);

            if (record == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                record.name = question_group.name;
                record.number = question_group.number;
                record.semester = question_group.semester;
                gropuService.update(record);
                return RedirectToAction("Index");
            }
            return View(question_group);
        }

        // GET: Admin/Question_group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_group question_group = gropuService.selectById(id);
            if (question_group == null)
            {
                return HttpNotFound();
            }
            return View(question_group);
        }

        // POST: Admin/Question_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gropuService.deleteByPrimaryKey(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                gropuService.disposing();
            }
            base.Dispose(disposing);
        }
    }
}
