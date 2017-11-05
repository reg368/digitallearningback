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

        public int updatePercentageById(int id , int percentage)
        {
            var model = db.Question_Concept_Mapping.Where(m => m.id == id).
                        FirstOrDefault<Question_Concept_Mapping>();
            if (model != null) {
                model.percentage = percentage;
                db.Entry(model).State = EntityState.Modified;
            }
            return db.SaveChanges();
        }

    }
}