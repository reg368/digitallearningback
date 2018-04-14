using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using digitallearningback.Models;
using System.Data.SqlClient;

namespace digitallearningback.DAO
{
    public class QuestionnaireService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int selectIsStudentMultiTestQuestionnaire(int userid)
        {
            var result = db.Database.SqlQuery<int>(
                "select dbo.fun_FindIsStudentMultiTestQuestionnaire(@userid) as result", 
                new SqlParameter("@userid", userid)).FirstOrDefault();
            return result;
        }

    }
}