using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Cimage_moodsMD))]
    public partial class Cimage_moods
    {
        public class Cimage_moodsMD
        {
            [Display(Name = "表情")]
            public string cmood_title { get; set; }
        }
    }
}