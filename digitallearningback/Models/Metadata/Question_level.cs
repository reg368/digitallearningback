﻿using System;
using System.ComponentModel.DataAnnotations;

namespace digitallearningback.Models
{
    [MetadataType(typeof(Question_levelMD))]
    public partial class Question_level
    {
        public class Question_levelMD
        {
            [Required]
            [Display(Name = "關卡名稱")]
            public string level { get; set; }

            [Required]
            [Display(Name = "是否啟用")]
            public Nullable<int> isvisible { get; set; }

            [Required]
            [Display(Name = "是否隨機出題")]
            public Nullable<int> israndom { get; set; }

            [Required]
            [Display(Name = "關卡編號")]
            public Nullable<int> levelorder { get; set; }

            [Display(Name = "答對題數過關")]
            public Nullable<int> correctqnumber { get; set; }

            [Display(Name = "過關金錢")]
            public Nullable<int> awardmoney { get; set; }

            [Display(Name = "過關經驗值")]
            public Nullable<int> awardexperience { get; set; }
        }
    }
}