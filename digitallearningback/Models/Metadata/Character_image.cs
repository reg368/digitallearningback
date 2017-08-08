using System;
using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Character_imageMD))]
    public partial class Character_image
    {
        public class Character_imageMD
        {
            [Display(Name = "圖片")]
            public string cimage_path { get; set; }

            [Required]
            [Display(Name = "表情")]
            public Nullable<int> cimage_mood { get; set; }

            [Required]
            [Display(Name = "性別")]
            public string cimage_gander { get; set; }

            [Required]
            [Display(Name = "職業")]
            public Nullable<int> cimage_profession { get; set; }

            [Required]
            [Display(Name = "等級")]
            public Nullable<int> image_level { get; set; }
        }
    }
}