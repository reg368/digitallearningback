using digitallearningback.DAO;
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
        private VW_QuestionConceptDetailService vw_service = new VW_QuestionConceptDetailService();
        private QuestionService questionservice = new QuestionService();
        private Question_ConceptService conceptservice = new Question_ConceptService();

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
        public ActionResult Create(int qid, String qtext)
        {
            ViewBag.conceptlist = conceptservice.selectListByWhereNotInQid(qid);
            return View(questionservice.selectById(qid));
        }
    }
}