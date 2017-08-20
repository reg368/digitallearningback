using System;
using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(AnswerMD))]
    public partial class Answer
    {
        public class AnswerMD
        {
            [Display(Name = "選項文字")]
            public string text { get; set; }

            [Display(Name = "選項圖片")]
            public string pic_path { get; set; }

            [Required]
            [Display(Name = "是否正確")]
            public Nullable<int> is_correct { get; set; }
            
        }
    }
}