using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class Question_Concept_GroupController : Controller
    {
        private InfoUser infoUser = SessionHelper.getLoginUser();
        private Question_Concept_GroupService service = new Question_Concept_GroupService();

        // GET: Admin/Question_Concept_Group
        public ActionResult Index()
        {
            return View(service.selectListByUserid(infoUser.id));
        }

        // GET: Admin/Question_Concept_Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept_Group question_Concept_Group = service.selectById(id);
            if (question_Concept_Group == null)
            {
                return HttpNotFound();
            }
            return View(question_Concept_Group);
        }

        // GET: Admin/Question_Concept_Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Question_Concept_Group/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Question_Concept_Group question_Concept_Group)
        {
            if (ModelState.IsValid)
            {
                question_Concept_Group.user_id = infoUser.id;
                service.insert(question_Concept_Group);
                return RedirectToAction("Index");
            }

            return View(question_Concept_Group);
        }

        // GET: Admin/Question_Concept_Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept_Group question_Concept_Group = service.selectById(id);
            if (question_Concept_Group == null)
            {
                return HttpNotFound();
            }
            return View(question_Concept_Group);
        }

        // POST: Admin/Question_Concept_Group/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Question_Concept_Group question_Concept_Group)
        {
            if (ModelState.IsValid)
            {
                Question_Concept_Group record = service.selectById(question_Concept_Group.id);
                record.name = question_Concept_Group.name;

                service.update(record);

                return RedirectToAction("Index");
            }
            return View(question_Concept_Group);
        }

        // GET: Admin/Question_Concept_Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Concept_Group question_Concept_Group = service.selectById(id);
            if (question_Concept_Group == null)
            {
                return HttpNotFound();
            }
            return View(question_Concept_Group);
        }

        // POST: Admin/Question_Concept_Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.deleteByPrimaryKey(id);
            return RedirectToAction("Index");
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
