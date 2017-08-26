using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public List<Cimage_profession> selectAll()
        {
            var linq = db.Cimage_profession.SqlQuery("Select * from Cimage_profession where 1=1");
            return linq.ToList<Cimage_profession>();
        }

        public DbSet<Cimage_profession> getDbSet()
        {
            return db.Cimage_profession;
        }
    }
}