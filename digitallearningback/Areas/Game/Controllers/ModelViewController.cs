using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace digitallearningback.Areas.Game.Controllers
{
    public class ModelViewController : Controller
    {
        // GET: Game/ModelView
        public ActionResult QuestionDetail()
        {
            return View();
        }
    }
}