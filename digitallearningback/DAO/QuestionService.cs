using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class QuestionService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question model)
        {
            db.Question.Add(model);
            return db.SaveChanges();
        }

        public int update(Question record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question record = db.Question.Find(pk);
            db.Question.Remove(record);
            return db.SaveChanges();
        }

        public Question selectById(int? id)
        {
            return db.Question.Find(id);
        }

        public List<Question> selectByGroupid(int groupid) {
            var linq = db.Question.Where(q => q.groupid == groupid);
            return linq.ToList<Question>();
        }
    }
}