using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Vw_QuestionConceptDetail))]
    public partial class vw_QuestionConceptDetail
    {
        public class Vw_QuestionConceptDetail
        {

            [Display(Name = "題目權重")]
            public int q_percentage { get; set; }

            [Display(Name = "概念名稱")]
            public string c_name { get; set; }

            [Display(Name = "概念權重")]
            public int c_percentage { get; set; }

            [Display(Name = "概念集名稱")]
            public string g_name { get; set; }

            [Display(Name = "概念集權重")]
            public int g_percentage { get; set; }

        }
    }
}