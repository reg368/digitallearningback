using System.Web.Mvc;
using digitallearningback.Models;
using digitallearningback.Util;

namespace digitallearningback.Areas.Game.Controllers
{
    public class CreateController : Controller
    {
        private InfoUser infoUser = SessionHelper.getLoginUser();
        // GET: Game/Create
        public ActionResult SelectGender()
        {
            return View(infoUser);
        }
    }
}