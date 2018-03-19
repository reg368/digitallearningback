using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace digitallearningback.DAO
{
    public class InfoUserService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(InfoUser model)
        {
            db.InfoUser.Add(model);
            return db.SaveChanges();
        }

        public int update(InfoUser record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            InfoUser record = db.InfoUser.Find(pk);
            db.InfoUser.Remove(record);
            return db.SaveChanges();
        }

        public InfoUser findByUserLoginId(string loginid)
        {
            var    lineQuery = db.InfoUser
                    .Include(u => u.Character_image1)
                    .Include(u => u.Character_image2)
                    .Where(u => u.login_id == loginid);
            return lineQuery.FirstOrDefault<InfoUser>();
        }

        //查有哪些角色在這一關卡中過關了
        //並且依照順序列出誰先過關
        //這邊的 infoUser 欄位 hp : 儲存過關分數
        public List<InfoUser> selectLevelPassedUser(int lid)
        {
            var linq = db.InfoUser.SqlQuery(
                       "select  u.id, u.name , u.gender , u.age , u.grade , u.character_image ,  " +
                        " u.character_name , u.pet_image , u.pet_name ,u.login_id, " +
                        " u.password , " +
                        " (select createTime from Answer_Level_Log where id = tb.sort) as joindate , " +
                        "u.cimage_type , u.pimage_type ," +
                        " u.login_count ,u.group_id ,u.teacher_id ,u.money , " +
                        " u.experience , " +
                        " (select CAST(passpoint as int) from Answer_Level_Log where id = tb.sort) as hp  , " +
                        "  u.dept ,  u.nickname, tb.sort  " +
                       "from InfoUser u join " + 
                           " ( "+
                           " select g.userid as userid , MIN(g.id) as sort  from " +
                           " Answer_Level_Log g join Question_level l  " +
                           " on g.lid = l.id" +
                           " where  g.lid = @lid and " +
                           " g.passpoint >= l.minpasspoint" +
                           " group by g.userid " + 
                           ") as tb" +
                       " on u.id = tb.userid "+
                       "order by hp desc , sort "
                       , new SqlParameter("@lid", lid)
                       );

            return linq.ToList<InfoUser>();
        }

    }
}