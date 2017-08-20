using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class AnswerService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Answer model)
        {
            db.Answer.Add(model);
            return db.SaveChanges();
        }

        public int update(Answer record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Answer record = db.Answer.Find(pk);
            db.Answer.Remove(record);
            return db.SaveChanges();
        }

        public Answer selectById(int? id)
        {
            return db.Answer.Find(id);
        }

        public List<Answer> selectByQid(int? qid) {
            var linq = db.Answer.Where(a => a.qid == qid);
            return linq.ToList<Answer>();
        }
    }
}