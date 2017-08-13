using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
	public class Question_groupService
	{
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(Question_group model)
        {
            db.Question_group.Add(model);
            return db.SaveChanges();
        }

        public int update(Question_group record)
        {
            db.Entry(record).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int deleteByPrimaryKey(int pk)
        {
            Question_group record = db.Question_group.Find(pk);
            db.Question_group.Remove(record);
            return db.SaveChanges();
        }

        public Question_group selectById(int? id)
        {
            return db.Question_group.Find(id);
        }

        public List<Question_group> selectListByUserid(int userid)
        {
            var linq = db.Question_group.Where(q => q.userid == userid);
            return linq.ToList<Question_group>();
        }

    }
}
