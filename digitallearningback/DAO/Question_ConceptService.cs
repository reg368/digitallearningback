using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Question_ConceptService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question_Concept model)
        {
            db.Question_Concept.Add(model);
            return db.SaveChanges();
        }

        public int update(Question_Concept record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question_Concept record = db.Question_Concept.Find(pk);
            db.Question_Concept.Remove(record);
            return db.SaveChanges();
        }

        public Question_Concept selectById(int? id)
        {
            return db.Question_Concept.Find(id);
        }

        public List<Question_Concept> selectListByGroupid(int groupid) {
            var linq = db.Question_Concept.Where(c => c.group_id == groupid);
            return linq.ToList<Question_Concept>();
        }
    }
}