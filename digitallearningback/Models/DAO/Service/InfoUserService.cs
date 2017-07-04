using System;
using digitallearningback.Models.DAO.Implements;
using digitallearningback.Models.DAO.Interface;

namespace digitallearningback.Models.DAO.Service
{
    public class InfoUserService : InfoUser_in
    {

        private InfoUser_im dao;

        public InfoUserService() {
            dao = new InfoUser_im(); 
        }

        public InfoUser findByUserLoginId(string loginid)
        {
          return  dao.findByUserLoginId(loginid);
        }
    }
}