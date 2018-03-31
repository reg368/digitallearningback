using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace digitallearningback.DAO
{
    public class VW_DataAnalysisLevelDetailInfoService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public vw_DataAnalysisLevelDetailInfo selectByLevelId(int lid)
        {
            return db.vw_DataAnalysisLevelDetailInfo.Where(d => d.lid == lid).FirstOrDefault<vw_DataAnalysisLevelDetailInfo>();
        }
    }
}