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
    
    public partial class InfoUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InfoUser()
        {
            this.Answer_Group_Log = new HashSet<Answer_Group_Log>();
            this.Answer_Log = new HashSet<Answer_Log>();
            this.Student_Class = new HashSet<Student_Class>();
            this.Student_Class_Mapping = new HashSet<Student_Class_Mapping>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
        public Nullable<int> character_image { get; set; }
        public Nullable<int> pet_image { get; set; }
        public string pet_name { get; set; }
        public string login_id { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> joindate { get; set; }
        public string cimage_type { get; set; }
        public string pimage_type { get; set; }
        public Nullable<int> login_count { get; set; }
        public Nullable<int> group_id { get; set; }
        public string teacher_id { get; set; }
        public Nullable<int> money { get; set; }
        public Nullable<int> experience { get; set; }
        public Nullable<int> hp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer_Group_Log> Answer_Group_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer_Log> Answer_Log { get; set; }
        public virtual Character_image Character_image1 { get; set; }
        public virtual Character_image Character_image2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Class> Student_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Class_Mapping> Student_Class_Mapping { get; set; }


    }
}
