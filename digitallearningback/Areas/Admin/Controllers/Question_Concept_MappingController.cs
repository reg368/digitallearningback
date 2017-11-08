using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class Question_Concept_MappingController : Controller
    {
        private Log4Net logger = new Log4Net("Question_Concept_MappingController");
        private VW_QuestionConceptDetailService vw_service = new VW_QuestionConceptDetailService();
        private QuestionService questionservice = new QuestionService();
        private Question_ConceptService conceptservice = new Question_ConceptService();
        private Question_Concept_MappingService qcmservice = new Question_Concept_MappingService();

        // GET: Admin/Question_Concept_Mapping
        public ActionResult Index(int? qid)
        {
            if (qid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            else
            {
                ViewBag.conceptlist  = vw_service.selectByQid(qid);
                return View(questionservice.selectById(qid));
            }
        }

        // GET: Admin/Question_Concept_Mapping
        public ActionResult AddConcept(int qid)
        {
            ViewBag.conceptlist = conceptservice.selectListByWhereNotInQid(qid);
            return View(questionservice.selectById(qid));
        }

        // GET: Admin/Question_Concept_Mapping
        public ActionResult DoAddConcept(int? qid,IEnumerable<String> cids)
        {

            if (qid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (cids == null)
            {
                ModelState.AddModelError("error", "請選擇欲加入至題目的概念");
                return RedirectToAction("AddConcept", new { qid = qid });
            }

            List<Question_Concept_Mapping> models = new List<Question_Concept_Mapping>();

            foreach (String cid in cids)
            {
                Question_Concept_Mapping model = new Question_Concept_Mapping();
                model.c_id = Convert.ToInt32(cid); ;
                model.q_id = qid;
                model.percentage = 0;
                models.Add(model);
            }

            if (models.Count > 0)
            {
                qcmservice.insert(models);
                return RedirectToAction("Index", new { qid = qid });
            }
            else
            {
                ModelState.AddModelError("error", "請選擇欲加入至題目的概念");
                return RedirectToAction("AddQuestion", new { qid = qid });
            }
        }

        public ActionResult DoEditConceptPercentage(int qid,ICollection<String> percentages, ICollection<String> ids)
        {
            if (percentages == null || ids == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (percentages.Count != ids.Count) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            for (int i = 0; i < percentages.Count; i++) {
                qcmservice.updatePercentageById(
                    Convert.ToInt32(ids.ElementAtOrDefault(i)),
                     Convert.ToInt32(percentages.ElementAtOrDefault(i)));
            }

            return RedirectToAction("Index", new { qid = qid });
        }

        public ActionResult DoDelete(int id , int qid) {

            qcmservice.deleteByPrimaryKey(id);

            return RedirectToAction("Index", new { qid = qid });
        }
    }
}