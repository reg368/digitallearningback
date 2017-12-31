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
    public class Question_levelController : Controller
    {
        private Question_groupService groupservice = new Question_groupService();
        private Question_levelService levelService = new Question_levelService();

        // GET: Admin/Question_level
        public ActionResult Index(int id)
        {
            return View(groupservice.selectById(id));
        }

        /*
        // GET: Admin/Question_level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_level question_level = levelService.selectById(id);
            if (question_level == null)
            {
                return HttpNotFound();
            }
            return View(question_level);
        }
        */
        // GET: Admin/Question_level/Create
        public ActionResult Create(int id, String groupname)
        {
            ViewBag.groupname = groupname;
            ViewBag.group_id = id;
            return View();
        }

        // POST: Admin/Question_level/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "groupname")] String groupname,
            [Bind(Include = "group_id,levelorder,level,isvisible,passpoint,correctqnumber,minpasspoint")] Question_level question_level)
        {
            if (ModelState.IsValid)
            {
                levelService.insert(question_level);
                return RedirectToAction("Index", new { id = question_level.group_id});
            }

            ViewBag.groupname = groupname;
            ViewBag.group_id = question_level.group_id;

            return View(question_level);
        }


        // GET: Admin/Question_level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_level question_level = levelService.selectById(id);
            if (question_level == null)
            {
                return HttpNotFound();
            }
            return View(question_level);
        }

        // POST: Admin/Question_level/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "id,levelorder,level,isvisible,passpoint,correctqnumber,minpasspoint")] Question_level question_level)
        {

            Question_level record = levelService.selectById(question_level.id);

            if (record == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {

                record.level = question_level.level;
                record.isvisible = question_level.isvisible;
                record.levelorder = question_level.levelorder;
                record.passpoint = question_level.passpoint;
                record.correctqnumber = question_level.correctqnumber;
                record.minpasspoint = question_level.minpasspoint;

                levelService.update(record);

                return RedirectToAction("Index", new { id = record.group_id });
            }

            question_level.Question_group = record.Question_group;
            return View(question_level);
        }

        
       // GET: Admin/Question_level/Delete/5
       public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }

           Question_level question_level = levelService.selectById(id);

            if (question_level == null)
           {
               return HttpNotFound();
           }
            return View(question_level);
       }

       // POST: Admin/Question_level/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int id,int group_id)
       {
           levelService.deleteByPrimaryKey(id);
           return RedirectToAction("Index", new { id = group_id});
       }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                levelService.disposing();
            }
            base.Dispose(disposing);
        }
    }
}
