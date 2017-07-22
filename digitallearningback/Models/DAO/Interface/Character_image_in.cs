using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models.DAO.Interface
{
    interface Character_image_in
    {
        void insert(Character_image model);
        List<Character_image> selectAll();
    }
}