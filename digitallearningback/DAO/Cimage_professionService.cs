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

        public List<Cimage_profession> selectListForSelectCharacter()
        {
            var linq = db.Cimage_profession.SqlQuery("Select * from Cimage_profession " +
                "where cprofession_title not in ('寵物','敵人')");
            return linq.ToList<Cimage_profession>();
        }

        public DbSet<Cimage_profession> getDbSet()
        {
            return db.Cimage_profession;
        }
    }
}