﻿using System.Collections.Generic;
using System.Linq;
using digitallearningback.Models.DAO.Interface;
using digitallearningback.Util;

namespace digitallearningback.Models.DAO.Implements
{
    public class Character_image_im : Character_image_in
    {
        public List<Character_image> selectAll()
        {
            var lineQuery = from cimage in DBContextHelper.GetContext().Character_image
                          orderby cimage.cimage_profession
                          select cimage;
            return lineQuery.ToList<Character_image>();
        }
    }
}