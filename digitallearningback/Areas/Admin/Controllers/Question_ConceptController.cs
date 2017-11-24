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
    public class Question_ConceptController : Controller
    {
        private Question_ConceptService service = new Question_ConceptService();
        private Question_Concept_GroupService gservice = new Question_Concept_GroupService();
        private InfoUser infoUser = InfoUser.getLoginUser();

        // GET: Admin/Question_Concept
        public ActionResult Index(int id)
        {
            return View(gservice.selectById(id));
        }

        // GET: Admin/Question_Concept/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept question_Concept = service.selectById(id);
            if (question_Concept == null)
            {
                return HttpNotFound();
            }
            return View(question_Concept);
        }

        // GET: Admin/Question_Concept/Create
        public ActionResult Create(int gid,String gname)
        {
            ViewBag.gid = gid;
            ViewBag.gname = gname;
            ViewBag.userid = infoUser.id;
            return View();
        }

        // POST: Admin/Question_Concept/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "name,user_id,group_id,percentage")] Question_Concept question_Concept)
        {
            if (ModelState.IsValid)
            {
                service.insert(question_Concept);
                return RedirectToAction("Index",new { id = question_Concept.group_id});
            }
            return View(question_Concept);
        }

        
        // GET: Admin/Question_Concept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept question_Concept = service.selectById(id);
            if (question_Concept == null)
            {
                return HttpNotFound();
            }
           
            return View(question_Concept);
        }

        // POST: Admin/Question_Concept/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "id,name,percentage")] Question_Concept question_Concept)
        {
            if (ModelState.IsValid)
            {
                Question_Concept record = service.selectById(question_Concept.id);
                record.name = question_Concept.name;
                record.percentage = question_Concept.percentage;
                service.update(record);
                return RedirectToAction("Index", new { id = record.group_id });
            }
             
            return View(question_Concept);
        }

        
        // GET: Admin/Question_Concept/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept question_Concept = service.selectById(id);
            if (question_Concept == null)
            {
                return HttpNotFound();
            }
            return View(question_Concept);
        }

        // POST: Admin/Question_Concept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,int gid)
        {
            service.deleteByPrimaryKey(id);
            return RedirectToAction("Index",new { id = gid });
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.disposing();
            }
            base.Dispose(disposing);
        }
    }
}
