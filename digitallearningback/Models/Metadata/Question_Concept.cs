using System;
using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Question_ConceptMD))]
    public partial class Question_Concept
    {
        public class Question_ConceptMD
        {
            [Required]
            [Display(Name = "子概念名稱")]
            public string name { get; set; }

            [Required]
            [Display(Name = "比重")]
            public Nullable<int> percentage { get; set; }
        }
    }
}