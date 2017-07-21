using System.Web.Mvc;
using digitallearningback.Models;
using digitallearningback.Models.DAO.Service;

namespace digitallearningback.Controllers
{
    public class GameImageController : Controller
    {
        private Character_imageService character_imageService = new Character_imageService();

        // GET: GameImage
        public ActionResult Index()
        {
            var cimages = character_imageService.selectAll();
            return View(cimages);
        }

        public ActionResult CreateView()
        {
            var moods = new Cimage_moodService().selectAll();
            var professions = new Cimage_professionService().selectAll();

            ViewBag.optionmMods = new SelectList(moods, "cmood_id", "cmood_title");
            ViewBag.optionProfessions = new SelectList(professions, "cprofession_id", "cprofession_title");

            return View();
        }
    }
}