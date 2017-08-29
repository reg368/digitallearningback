using System.Collections.Generic;
using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace digitallearningback.DAO
{
    public class Character_imageService
    {

        private yzucsEntities db = new yzucsEntities();

        public void disposing() {
            if (db != null) {
                db.Dispose();
            }
        }

        public int insert(Character_image model) {
            db.Character_image.Add(model);
            return db.SaveChanges();
        }

        public int update(Character_image record) {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk){
            Character_image character_image = db.Character_image.Find(pk);
            db.Character_image.Remove(character_image);
            return db.SaveChanges();
        }

        public Character_image selectById(int? id) {
           return db.Character_image.Find(id);
        }

        public List<Character_image> selectAllInclude()
        {
            var linq = db.Character_image.Include(c => c.Cimage_mood1).Include(c => c.Cimage_profession1);
            return linq.ToList();
        }

        public List<Character_image> selectListByGenderAndPro(string gender , int pid)
        {
            var linq = db.Character_image.Where(c => 
                    c.cimage_gander == gender && 
                    c.cimage_profession == pid &&
                    c.image_level == 1);
            return linq.ToList();
        }

        public List<Character_image> selectListByProName(string pname)
        {
            var linq = db.Character_image.SqlQuery("Select a.* from Character_image a join Cimage_profession b" +
                " on a.cimage_profession = b.cprofession_id " +
                "where b.cprofession_title = @pname ", 
                new SqlParameter("@pname", pname));
            return linq.ToList();
        }
    }
}