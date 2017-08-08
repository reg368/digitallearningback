using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Cimage_professionMD))]
    public partial class Cimage_profession
    {
        public class Cimage_professionMD
        {
            [Display(Name = "職業")]
            public string cprofession_title { get; set; }
        }
    }
}