using System.Collections.Generic;
using System.Linq;
using digitallearningback.Models.DAO.Interface;
using digitallearningback.Util;

namespace digitallearningback.Models.DAO.Implements
{
    public class Cimage_mood_im : Cimage_mood_in
    {
        public List<Cimage_mood> selectAll()
        {
            var linqQuery = from mood in DBContextHelper.GetContext().Cimage_mood
                            orderby mood.cmood_id
                            select mood;
            return linqQuery.ToList<Cimage_mood>();
        }
    }
}