using System.Collections.Generic;
using digitallearningback.Models.DAO.Implements;
using digitallearningback.Models.DAO.Interface;

namespace digitallearningback.Models.DAO.Service
{
    public class Cimage_professionService : Cimage_profession_in
    {
        private Cimage_profession_im dao = new Cimage_profession_im();

        public List<Cimage_profession> selectAll()
        {
            return dao.selectAll();
        }
    }
}