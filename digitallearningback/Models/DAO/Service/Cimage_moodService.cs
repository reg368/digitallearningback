using System.Collections.Generic;
using digitallearningback.Models.DAO.Implements;
using digitallearningback.Models.DAO.Interface;

namespace digitallearningback.Models.DAO.Service
{
    public class Cimage_moodService : Cimage_mood_in
    {
        private Cimage_mood_im dao = new Cimage_mood_im();

        public List<Cimage_mood> selectAll()
        {
            return dao.selectAll();
        }
    }
}