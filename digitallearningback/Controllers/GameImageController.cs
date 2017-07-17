using System.Web.Mvc;
using digitallearningback.Models.DAO.Service;

namespace digitallearningback.Controllers
{
    public class GameImageController : Controller
    {
        // GET: GameImage
        public ActionResult Index()
        {
            var cimages = new Character_imageService().selectAll();
            return View(cimages);
        }
    }
}