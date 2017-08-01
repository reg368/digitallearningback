using System.Collections.Generic;
using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;

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
            return linq.ToList<Character_image>();
        }
    }
}