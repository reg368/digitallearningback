using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    public class EditCharNameViewMD
    {
        [Required]
        [Display(Name = "角色名稱")]
        public string character_name { get; set; }
        [Required]
        [Display(Name = "寵物名稱")]
        public string pet_name { get; set; }

    }
}