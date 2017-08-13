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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question_level()
        {
            this.Answer_Group_Log = new HashSet<Answer_Group_Log>();
            this.Question_Level_Mapping = new HashSet<Question_Level_Mapping>();
        }
    
        public int id { get; set; }
        public string level { get; set; }
        public Nullable<System.DateTime> joindate { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> isvisible { get; set; }
        public Nullable<int> israndom { get; set; }
        public Nullable<int> levelorder { get; set; }
        public Nullable<int> correctqnumber { get; set; }
        public Nullable<int> awardmoney { get; set; }
        public Nullable<int> awardexperience { get; set; }
        public Nullable<int> fromquestion { get; set; }
        public Nullable<int> toquestion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer_Group_Log> Answer_Group_Log { get; set; }
        public virtual Question_group Question_group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question_Level_Mapping> Question_Level_Mapping { get; set; }
    }
}
