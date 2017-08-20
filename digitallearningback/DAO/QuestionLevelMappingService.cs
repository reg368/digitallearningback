using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class QuestionLevelMappingService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question_Level_Mapping model)
        {
            db.Question_Level_Mapping.Add(model);
            return db.SaveChanges();
        }

        public int insert(List<Question_Level_Mapping> models)
        {
            db.Question_Level_Mapping.AddRange(models);
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question_Level_Mapping record = db.Question_Level_Mapping.Find(pk);
            db.Question_Level_Mapping.Remove(record);
            return db.SaveChanges();
        }

        public int deleteByLid(int lid)
        {
            db.Database.ExecuteSqlCommand(
                TransactionalBehavior.EnsureTransaction,
                "Delete from Question_Level_Mapping where lid = @lid",
                new SqlParameter("@lid", lid)
                );
            return db.SaveChanges();
        }


    }
}