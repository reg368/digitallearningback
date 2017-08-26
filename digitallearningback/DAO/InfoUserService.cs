using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;

namespace digitallearningback.DAO
{
    public class InfoUserService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(InfoUser model)
        {
            db.InfoUser.Add(model);
            return db.SaveChanges();
        }

        public int update(InfoUser record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            InfoUser record = db.InfoUser.Find(pk);
            db.InfoUser.Remove(record);
            return db.SaveChanges();
        }

        public InfoUser findByUserLoginId(string loginid)
        {
            var    lineQuery = db.InfoUser.Where(u => u.login_id == loginid);
            return lineQuery.FirstOrDefault<InfoUser>();
        }


    }
}