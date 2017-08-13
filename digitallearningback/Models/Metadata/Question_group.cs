using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Question_groupMD))]
    public partial class Question_group
    {
        public class Question_groupMD
        {
            [Required]
            [Display(Name = "課程名稱")]
            public string name { get; set; }
            [Display(Name = "課程編號")]
            public string number { get; set; }
            [Display(Name = "學期")]
            public string semester { get; set; }
        }
    }
}