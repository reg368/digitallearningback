//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace digitallearningback.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question_level
    {
        public decimal id { get; set; }
        public string level { get; set; }
        public Nullable<System.DateTime> joindate { get; set; }
        public Nullable<decimal> group_id { get; set; }
        public Nullable<decimal> isvisible { get; set; }
        public Nullable<decimal> israndom { get; set; }
        public Nullable<decimal> totalqnumber { get; set; }
        public Nullable<decimal> correctqnumber { get; set; }
        public Nullable<decimal> awardmoney { get; set; }
        public Nullable<decimal> awardexperience { get; set; }
        public Nullable<decimal> fromquestion { get; set; }
        public Nullable<decimal> toquestion { get; set; }
    }
}
