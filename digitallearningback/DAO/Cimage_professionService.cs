using System.Data.Entity;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Cimage_professionService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public DbSet<Cimage_profession> getDbSet()
        {
            return db.Cimage_profession;
        }
    }
}