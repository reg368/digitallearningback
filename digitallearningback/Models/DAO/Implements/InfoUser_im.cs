using System.Linq;
using digitallearningback.Models.DAO.Interface;
using digitallearningback.Util;

namespace digitallearningback.Models.DAO.Implements
{
    public class InfoUser_im : InfoUser_in
    {
        public InfoUser findByUserLoginId(string loginid)
        {
            var lineQuery = DBContextHelper.GetContext().InfoUser.Where(u=>u.login_id == loginid);
            return lineQuery.FirstOrDefault<InfoUser>();
        }  
    }
}