using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Game.Controllers
{
    public class ModelViewController : Controller
    {

        private QuestionService qservice = new QuestionService(); // 找 課程/關卡 題目

        // GET: Game/ModelView/QuestionDetail
        public ActionResult QuestionDetail(int qid)
        {
            Question question = qservice.selectByIdIncludeAnswer(qid);
            return View(question);
        }
    }
}