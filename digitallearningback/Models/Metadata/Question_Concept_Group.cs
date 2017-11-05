using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Question_Concept_GroupMD))]
    public partial class Question_Concept_Group
    {
        public class Question_Concept_GroupMD
        {
            [Required]
            [Display(Name = "概念集名稱")]
            public string name { get; set; }
            [Display(Name = "權重")]
            public int percentage { get; set; }
        }
    }
}