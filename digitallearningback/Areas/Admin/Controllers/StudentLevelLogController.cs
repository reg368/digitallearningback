using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class StudentLevelLogController : Controller
    {
        private Question_levelService levelService = new Question_levelService();
        private Question_groupService groupservice = new Question_groupService();
        private VW_StudentLevelLogService stservice = new VW_StudentLevelLogService();

        
        public ActionResult Index()
        {

            List<Question_group> groups = groupservice.selectAll();

            return View(groups);
        }

        
        public ActionResult ViewRecord(int lid)
        {

            Question_level level = levelService.selectById(lid);
            ViewBag.levelname = level.level;
            ViewBag.groupname = level.Question_group.name;

            List<vw_StudentAnswerLevelLog>  levellog = stservice.selectListBylid(lid);

            return View(levellog);
        }

    }
}