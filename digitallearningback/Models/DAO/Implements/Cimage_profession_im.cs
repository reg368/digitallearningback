using System.Collections.Generic;
using System.Linq;
using digitallearningback.Models.DAO.Interface;
using digitallearningback.Util;

namespace digitallearningback.Models.DAO.Implements
{
    public class Cimage_profession_im : Cimage_profession_in
    {
        public List<Cimage_profession> selectAll()
        {
            var linq = from pro in DBContextHelper.GetContext().Cimage_profession
                       orderby pro.cprofession_id
                       select pro;
            return linq.ToList<Cimage_profession>();
        }
    }
}