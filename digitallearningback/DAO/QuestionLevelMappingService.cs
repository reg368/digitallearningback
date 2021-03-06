﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class QuestionLevelMappingService
    {
        private yzucsEntities db = new yzucsEntities();

        public void disposing()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        public int insert(List<Question_Level_Mapping> models)
        {
            db.Question_Level_Mapping.AddRange(models);
            return db.SaveChanges();
        }

        public int deleted(List<Question_Level_Mapping> models)
        {
            db.Question_Level_Mapping.RemoveRange(models);
            return db.SaveChanges();
        }

        public int deleted(String ids) {
            return db.Database.ExecuteSqlCommand(
                string.Format("Delete from Question_Level_Mapping where id in ({0})",ids)
                );
        }

        public List<Question_Level_Mapping> selectBylid(int lid)
        {
            var linq = db.Question_Level_Mapping.Where(l => l.l_id == lid);
            return linq.ToList<Question_Level_Mapping>();
        }

    }
}