using System;
using System.Linq;
using digitallearningback.Models.DAO.Interface;

namespace digitallearningback.Models.DAO.Implements
{
    public class InfoUser_im : InfoUser_in
    {
        public InfoUser findByUserLoginId(string loginid)
        {
            var context = DBContextHelper.getContext();
            return context.InfoUsers.SqlQuery("Select * from InfoUser where login_id =  @p0 ",loginid).FirstOrDefault<InfoUser>();
        }  
    }
}