using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class vw_StudentAnswerLevelLog
    {
        //passpoint 過關分數換算 幾顆星星
        //例: 過關分數 80 / 20 = 3 , 3顆星星
        public string getCorrectPasspointStar(int? point)
        {
            //logger.debug("getPasspointStar", "init passpoint : "+ passpoint);

            if (point != null && point > 0)
            {
                point = point / 20;
            }

            if (point < 0)
            {
                point = 0;
            }

            //logger.debug("getPasspointStar", "after calculate passpoint : " + passpoint);

            string star = "";

            for (int i = 0; i < point; i++)
            {
                star = star + "★";
            }

            return star;
        }
    }
}