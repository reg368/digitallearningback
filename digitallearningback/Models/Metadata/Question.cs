using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    [MetadataType(typeof(QuestionMD))]
    public partial class Question
    {
        public class QuestionMD
        {
            [Display(Name = "題目")]
            public string text { get; set; }

            [Display(Name = "分數")]
            public string point { get; set; }
           
            [Display(Name = "提示")]
            public string tip { get; set; }

            [Display(Name = "圖片")]
            public string pic_path { get; set; }
        }
    }
}