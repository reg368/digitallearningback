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

        public int insertQuestionnaire_data(Questionnaire_data model)
        {
            db.Questionnaire_data.Add(model);
            return db.SaveChanges();
        }

        public int selectCountForQuestionnaire_main()
        {
            var result = db.Database.SqlQuery<int>(
               "select count(*) from Questionnaire_main").FirstOrDefault();
            return result;
        }

        public Questionnaire_main selectQuestionnaire_mainByShow_order(int show_order) {
            var query = db.Questionnaire_main.SqlQuery(
                "Select * from Questionnaire_main where show_order = @show_order",
                new SqlParameter("@show_order", show_order));
            return query.FirstOrDefault<Questionnaire_main>();
        }

        public List<Questionnaire_option> selectQuestionnaire_optionByMain_id(int main_id) {
            var query = db.Questionnaire_option.SqlQuery(
               "Select * from Questionnaire_option where main_id = @main_id",
               new SqlParameter("@main_id", main_id));
            return query.ToList<Questionnaire_option>();
        }
    }
}