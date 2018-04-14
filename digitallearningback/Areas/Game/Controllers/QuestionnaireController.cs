using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;
using digitallearningback.Util;
using digitallearningback.Areas.Game.Models;
using digitallearningback.Filter;

namespace digitallearningback.Areas.Game.Controllers
{
    public class QuestionnaireController : Controller
    {
        private QuestionnaireService qservice = new QuestionnaireService();

        // GET: Game/Create
        public ActionResult Index()
        {
            return View();
        }

        [SkipMyGlobalActionFilter]
        public ActionResult GETIsStudentMultiTestQuestionnaire(int userid)
        {
            int ismultiTest =  qservice.selectIsStudentMultiTestQuestionnaire(userid);
            IsQuestionnaireMultiTest_json model = new IsQuestionnaireMultiTest_json();
            model.ismultiTest = ismultiTest;
            model.statuscode = 1;
            model.message = "success";
            return Json(model);
        }

        [SkipMyGlobalActionFilter]
        public ActionResult GETQuestionnaire_info(int current_index)
        {
            JsonStatus status = new JsonStatus();
            int total_question = qservice.selectCountForQuestionnaire_main();
            Questionnaire_main main = qservice.selectQuestionnaire_mainByShow_order(current_index);
            Questionnaire_main_json main_json = null;
            List<Questionnaire_option_json> option_list_json = null;
            if (main != null)
            {
                main_json = new Questionnaire_main_json();
                main_json.id = main.id;
                main_json.text = main.text;
                main_json.show_order = main.show_order;

                List<Questionnaire_option>  option_list = qservice.selectQuestionnaire_optionByMain_id(main.id);
                if (option_list != null) {
                    option_list_json = new List<Questionnaire_option_json>();
                    foreach (Questionnaire_option option in option_list)
                    {
                        Questionnaire_option_json option_json = new Questionnaire_option_json();
                        option_json.id = option.id;
                        option_json.main_id = option.main_id;
                        option_json.text = option.text;
                        option_json.show_order = option.show_order;
                        option_list_json.Add(option_json);
                    }
                }
            }

            Questionnaire_info_json info = new Questionnaire_info_json();
            info.current_index = current_index;
            info.total_question = total_question;
            info.questionnaire_Main = main_json;
            info.option_list = option_list_json;
            if (current_index > total_question) {
                info.statuscode = 2;  
                info.message = "questionnaire is finished";
            }
            else if (main_json != null && option_list_json != null)
            {
                info.statuscode = 1;
                info.message = "success";
            }
            else
            {
                info.statuscode = 0;
                info.message = "questionnaire is not exist";
            }
           

            return Json(info);

        }

        [SkipMyGlobalActionFilter]
        public ActionResult PUTQuestionnaire_data(int userid , int main_id , int option_id)
        {
            Questionnaire_data data = new Questionnaire_data();
            JsonStatus status = new JsonStatus();

            data.userid = userid;
            data.main_id = main_id;
            data.option_id = option_id;
            data.createTime = System.DateTime.Now;

            int result = qservice.insertQuestionnaire_data(data);

            status.statuscode = result;
            if (result == 1)
            {
                status.message = "success";
            }
            else
            {
                status.message = "fail";
            }
           
            return Json(status);

        }

    }
}