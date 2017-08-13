using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Question_levelService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question_level model)
        {
            db.Question_level.Add(model);
            return db.SaveChanges();
        }

        public int update(Question_level record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question_level record = db.Question_level.Find(pk);
            db.Question_level.Remove(record);
            return db.SaveChanges();
        }

        public Question_level selectById(int? id)
        {
            return db.Question_level.Find(id);
        }

        public List<Question_level> selectListByGroupid(int groupid)
        {
            var linq = db.Question_level.Where(l => l.group_id == groupid).OrderBy(l => l.levelorder);
            return linq.ToList<Question_level>();
        }
    }
}