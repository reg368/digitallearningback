using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class VW_QuestionConceptDetailService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }


        public List<vw_QuestionConceptDetail> selectByQid(int? qid) {
            var linq = db.vw_QuestionConceptDetail.Where(a => a.q_id == qid);
            return linq.ToList<vw_QuestionConceptDetail>();
        }
    }
}