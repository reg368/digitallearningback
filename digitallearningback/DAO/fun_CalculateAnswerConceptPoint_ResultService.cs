using digitallearningback.Models;
using System.Linq;
using System.Collections.Generic;

namespace digitallearningback.DAO
{
    public class fun_CalculateAnswerConceptPoint_ResultService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public List<fun_CalculateAnswerConceptPoint_Result> selectByLevelLogId(int levellogid)
        {
            return db.fun_CalculateAnswerConceptPoint(levellogid).ToList();
        }

    }
}