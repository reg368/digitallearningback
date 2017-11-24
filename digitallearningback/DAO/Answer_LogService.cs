using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;

namespace digitallearningback.DAO
{
    public class Answer_LogService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Answer_Log model)
        {
            db.Answer_Log.Add(model);
            return db.SaveChanges();
        }

        public int update(Answer_Log record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Answer_Log record = db.Answer_Log.Find(pk);
            db.Answer_Log.Remove(record);
            return db.SaveChanges();
        }

    }
}