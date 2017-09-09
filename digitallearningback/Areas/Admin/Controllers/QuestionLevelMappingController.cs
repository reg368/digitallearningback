using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class QuestionLevelMappingController : Controller
    {
        private QuestionService qservice = new QuestionService();
        private Question_levelService qlservice = new Question_levelService();
        private QuestionLevelMappingService service = new QuestionLevelMappingService();

        // GET: Admin/QuestionLevelMapping
        public ActionResult Index(int id)
        {
            Question_level level = qlservice.selectById(id);
            ViewBag.level = level;
            return View(service.selectBylid(id));
        }

        public ActionResult AddQuestion(int gid,int lid)
        {
            Question_level level = qlservice.selectById(lid);
            ViewBag.level = level;
            return View(qservice.selectQuesitonLevelAddable(gid, lid));
        }

        public ActionResult DoAddQuestion(int? gid, int? lid, IEnumerable<String> qids)
        {
            if (gid == null || lid == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if(qids == null)
            {
                ModelState.AddModelError("error", "請選擇欲加入至關卡的題目");
                return RedirectToAction("AddQuestion", new { gid = gid, lid = lid });
            }

            List<Question_Level_Mapping> models = new List<Question_Level_Mapping>();
            
            foreach (String qid in qids)
            {
                Question_Level_Mapping model = new Question_Level_Mapping();
                model.g_id = gid;
                model.q_id = Convert.ToInt32(qid);
                model.l_id = lid;
                models.Add(model);
            }

            if (models.Count > 0)
            {
                service.insert(models);
                return RedirectToAction("Index", new { id = lid });
            }
            else
            {
                ModelState.AddModelError("error", "請選擇欲加入至關卡的題目");
                return RedirectToAction("AddQuestion", new { gid = gid, lid = lid });
            }
        }

        public ActionResult DeleteQuestion(int gid, int lid)
        {
            Question_level level = qlservice.selectById(lid);
            ViewBag.level = level;
            return View(service.selectBylid(lid));
        }


        public ActionResult DoDeleteQuestion(int? gid, int? lid, IEnumerable<String> mappingids)
        {
            if (gid == null || lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (mappingids == null || mappingids.Count() <= 0)
            {
                ModelState.AddModelError("error", "請選擇欲刪除關卡的題目");
                return RedirectToAction("DeleteQuestion", new { gid = gid, lid = lid });
            }

            string ids = mappingids.ContactString(",");

            service.deleted(ids);

            return RedirectToAction("Index", new { id = lid });
        }
    }
}