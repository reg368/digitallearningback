using System.IO;
using System.Linq;
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

        public ActionResult Create()
        {
        
            var moods = new Cimage_moodService().selectAll();
            var professions = new Cimage_professionService().selectAll();

            ViewData["moods"] = moods;
            ViewData["professions"] = professions;

            return View();
        }

       /* [HttpPost]
        public ActionResult Create(Character_image model) {

            var validImageTypes = new string[]{"image/jpg","image/jpeg"};

            if (model.imageUploadFile == null || model.imageUploadFile.ContentLength == 0) {
                ModelState.AddModelError("imageUploadFile", "This field is required");
            } else if (!validImageTypes.Any(t => t.Equals(model.imageUploadFile.ContentType))) {
                ModelState.AddModelError("imageUploadFile", "Only accept for jpg / jpeg file");
            }

            if (ModelState.IsValid) {
                var uploadDir = "~/Images/GameCharacter";
                var imagePath = Path.Combine(Server.MapPath(uploadDir), model.imageUploadFile.FileName);
                var imageUrl = Path.Combine(uploadDir, model.imageUploadFile.FileName);
                model.imageUploadFile.SaveAs(imagePath);
                model.cimage_path = imageUrl;
               
                character_imageService.insert(model);

                return RedirectToAction("Index");
            }

            return View(model);
        } */
    }
}