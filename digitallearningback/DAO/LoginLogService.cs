using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;

namespace digitallearningback.DAO
{
    public class LoginLogService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(LoginLog model)
        {
            db.LoginLog.Add(model);
            return db.SaveChanges();
        }

        public int update(LoginLog record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            LoginLog record = db.LoginLog.Find(pk);
            db.LoginLog.Remove(record);
            return db.SaveChanges();
        }

        public int doLog(InfoUser user)
        {
            LoginLog model = new LoginLog();
            model.userid = user.id;
            model.group_id = user.group_id;
            model.createTime = System.DateTime.Now;
            db.LoginLog.Add(model);
            return db.SaveChanges();
        }

    }
}