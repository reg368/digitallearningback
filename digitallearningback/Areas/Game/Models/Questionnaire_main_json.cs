using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Areas.Game.Models
{
    public class Questionnaire_main_json
    {
        public int id { get; set; }
        public string text { get; set; }
        public int? show_order { get; set; }
    }
}