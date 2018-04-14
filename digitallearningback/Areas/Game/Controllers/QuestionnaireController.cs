using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Game.Controllers
{
    public class QuestionnaireController : Controller
    {
        private InfoUserService uservice = new InfoUserService();
        private Log4Net logger = new Log4Net("QuestionnaireController");

        // GET: Game/Create
        public ActionResult Index()
        {
            return View();
        }

    }
}