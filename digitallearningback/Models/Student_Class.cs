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
    
    public partial class Student_Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_Class()
        {
            this.Group_Class_Mapping = new HashSet<Group_Class_Mapping>();
            this.Student_Class_Mapping = new HashSet<Student_Class_Mapping>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> teacher_id { get; set; }
        public Nullable<System.DateTime> joindate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group_Class_Mapping> Group_Class_Mapping { get; set; }
        public virtual InfoUser InfoUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Class_Mapping> Student_Class_Mapping { get; set; }
    }
}
