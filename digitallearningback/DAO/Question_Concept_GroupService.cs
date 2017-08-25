using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Question_Concept_GroupService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question_Concept_Group model)
        {
            db.Question_Concept_Group.Add(model);
            return db.SaveChanges();
        }

        public int update(Question_Concept_Group record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question_Concept_Group record = db.Question_Concept_Group.Find(pk);
            db.Question_Concept_Group.Remove(record);
            return db.SaveChanges();
        }

        public Question_Concept_Group selectById(int? id)
        {
            return db.Question_Concept_Group.Find(id);
        }

        public List<Question_Concept_Group> selectListByUserid(int userid) {
            var linq = db.Question_Concept_Group.Where(g => g.user_id == userid);
            return linq.ToList<Question_Concept_Group>();
        }
    }
}