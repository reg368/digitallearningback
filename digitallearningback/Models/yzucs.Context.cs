﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class yzucsEntities : DbContext
    {
        public yzucsEntities()
            : base("name=yzucsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Character_image> Character_image { get; set; }
        public virtual DbSet<Cimage_mood> Cimage_mood { get; set; }
        public virtual DbSet<Cimage_profession> Cimage_profession { get; set; }
        public virtual DbSet<Group_Class_Mapping> Group_Class_Mapping { get; set; }
        public virtual DbSet<InfoUser> InfoUser { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Question_Concept> Question_Concept { get; set; }
        public virtual DbSet<Question_Concept_Group> Question_Concept_Group { get; set; }
        public virtual DbSet<Question_Concept_Mapping> Question_Concept_Mapping { get; set; }
        public virtual DbSet<Question_group> Question_group { get; set; }
        public virtual DbSet<Question_level> Question_level { get; set; }
        public virtual DbSet<Question_Level_Mapping> Question_Level_Mapping { get; set; }
        public virtual DbSet<Student_Class> Student_Class { get; set; }
        public virtual DbSet<Student_Class_Mapping> Student_Class_Mapping { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<vw_QuestionConceptDetail> vw_QuestionConceptDetail { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Answer_Log> Answer_Log { get; set; }
    }
}
