using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace digitallearningback.DAO
{
    public class VW_StudentLevelLogService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public List<vw_StudentAnswerLevelLog> selectListBylid(int lid)
        {
            var linq = db.vw_StudentAnswerLevelLog.Where(
                g => g.lid == lid).OrderBy(g => g.levelorder).OrderBy(g => g.userid);
            return linq.ToList<vw_StudentAnswerLevelLog>();
        }
    }
}