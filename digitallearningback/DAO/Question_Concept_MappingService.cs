using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Question_Concept_MappingService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(List<Question_Concept_Mapping> models)
        {
            db.Question_Concept_Mapping.AddRange(models);
            return db.SaveChanges();
        }
    }
}