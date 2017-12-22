using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace digitallearningback.DAO
{
    public class Answer_Level_LogService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Answer_Level_Log model)
        {
            db.Answer_Level_Log.Add(model);
            return db.SaveChanges();
        }

        public int update(Answer_Level_Log record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Answer_Level_Log record = db.Answer_Level_Log.Find(pk);
            db.Answer_Level_Log.Remove(record);
            return db.SaveChanges();
        }

        public int selectMaxPasspointByUseridAndLevelid(int userid , int lid)
        {
            var linq = db.Database.SqlQuery<decimal>(
                "SELECT isnull(MAX(passpoint),0) as maxpasspoint" +
                " FROM Answer_Level_Log " +
               " where userid = @userid and lid = @lid ",
                new SqlParameter("@userid", userid),
                new SqlParameter("@lid", lid));
            return (int)linq.SingleOrDefault<decimal>();
        }

    }
}