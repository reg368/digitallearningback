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
    
    public partial class Answer_Log
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> loginid { get; set; }
        public Nullable<int> gid { get; set; }
        public Nullable<int> lid { get; set; }
        public Nullable<int> lidTimes { get; set; }
        public Nullable<int> qid { get; set; }
        public Nullable<int> aid { get; set; }
        public Nullable<int> iscorrect { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
    
        public virtual Answer Answer { get; set; }
        public virtual Question_group Question_group { get; set; }
        public virtual Question_level Question_level { get; set; }
        public virtual LoginLog LoginLog { get; set; }
        public virtual Question Question { get; set; }
        public virtual InfoUser InfoUser { get; set; }
    }
}
