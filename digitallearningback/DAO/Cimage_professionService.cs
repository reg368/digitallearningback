using System.Data.Entity;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Cimage_professionService
    {
        private yzucsEntities db = new yzucsEntities();

        public DbSet<Cimage_profession> getDbSet()
        {
            return db.Cimage_profession;
        }
    }
}