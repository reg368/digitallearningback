using System;

namespace digitallearningback.Models.DAO.Interface
{
    interface InfoUser_in
    {
        InfoUser findByUserLoginId(String loginid);
    }
}
