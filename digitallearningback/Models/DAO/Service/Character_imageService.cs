using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using digitallearningback.Models.DAO.Implements;
using digitallearningback.Models.DAO.Interface;

namespace digitallearningback.Models.DAO.Service
{
    public class Character_imageService : Character_image_in
    {
        private Character_image_im dao;

        public Character_imageService() {
            this.dao = new Character_image_im();
        }

        public void insert(Character_image model)
        {
            dao.insert(model);
        }

        public List<Character_image> selectAll()
        {
            return dao.selectAll();
        }
    }
}