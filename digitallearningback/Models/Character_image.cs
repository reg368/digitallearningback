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
    
    public partial class Character_image
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character_image()
        {
            this.InfoUser = new HashSet<InfoUser>();
            this.InfoUser1 = new HashSet<InfoUser>();
        }
    
        public int cimage_id { get; set; }
        public string cimage_path { get; set; }
        public Nullable<int> cimage_mood { get; set; }
        public string cimage_gander { get; set; }
        public Nullable<int> cimage_profession { get; set; }
        public Nullable<System.DateTime> cimage_joindate { get; set; }
        public Nullable<int> image_level { get; set; }
    
        public virtual Cimage_mood Cimage_mood1 { get; set; }
        public virtual Cimage_profession Cimage_profession1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoUser> InfoUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoUser> InfoUser1 { get; set; }
    }
}
