using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace digitallearningback.DAO
{
    public class VW_DataAnalysisIndexInfoService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public List<vw_DataAnalysisIndexInfo> selectAll()
        {
            return db.vw_DataAnalysisIndexInfo.ToList();
        }
    }
}