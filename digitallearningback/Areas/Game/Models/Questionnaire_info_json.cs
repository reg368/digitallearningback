using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using digitallearningback.Models;

namespace digitallearningback.Areas.Game.Models
{
    public class Questionnaire_info_json
    {
        public int total_question { get; set; }
        public int current_index { get; set; }
        public Questionnaire_main_json questionnaire_Main { get; set; }
        public List<Questionnaire_option_json> option_list { get; set; }
        public int statuscode { get; set; }
        public string message = "";

    }
}