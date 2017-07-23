using System.Linq;
using digitallearningback.Models;
using System.Data.Entity;

namespace digitallearningback.DAO
{
    public class InfoUserService
    {
        private yzucsEntities db = new yzucsEntities();

        public InfoUser findByUserLoginId(string loginid)
        {
            var lineQuery = db.InfoUser.Where(u => u.login_id == loginid);
            return lineQuery.FirstOrDefault<InfoUser>();
        }
    }
}