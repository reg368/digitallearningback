using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public Question selectByIdIncludeAnswer(int id)
        {
            return db.Question.Include(q => q.Answer).SingleOrDefault(q => q.id == id);
        }

        public List<Question> selectByGroupid(int groupid) {
            var linq = db.Question.Where(q => q.groupid == groupid);
            return linq.ToList<Question>();
        }

        public List<Question> selectByGroupidAndLevelid(int? groupid , int levelid)
        {
            var linq = db.Question.SqlQuery(
               "select * from Question where groupid = @gid " +
               "and id in(" +
               "select q.id from Question q join Question_Level_Mapping m " +
               "on q.id = m.q_id where m.l_id = @lid )",
                new SqlParameter("@gid", groupid),
                new SqlParameter("@lid", levelid));
            return linq.ToList<Question>();
        }

        public List<Question> selectQuesitonLevelAddable(int gid , int lid)
        {
            var list = db.Question.SqlQuery(
               "select * from Question where groupid = @gid " +
               "and id not in(" +
               "select q.id from Question q join Question_Level_Mapping m " +
               "on q.id = m.q_id where m.l_id = @lid )",
               new SqlParameter("@gid", gid),
               new SqlParameter("@lid", lid));
            return list.ToList<Question>();
        }
    }
}