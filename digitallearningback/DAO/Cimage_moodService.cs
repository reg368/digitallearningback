﻿using System.Data.Entity;
using digitallearningback.Models;

namespace digitallearningback.DAO
{
    public class Cimage_moodService
    {
        private yzucsEntities db = new yzucsEntities();

        public DbSet<Cimage_mood> getDbSet() {
            return db.Cimage_mood;
        }

    }
}