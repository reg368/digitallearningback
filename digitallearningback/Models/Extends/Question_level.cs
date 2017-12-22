using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Question_level
    {
        //passpoint 過關分數換算 幾顆星星
        //例: 過關分數 80 / 10 = 8 ; 8 - 5 = 3 *80分就是 = 3顆星
        public int?  getPasspointStarNumber() {

            if (this.passpoint != null && this.passpoint > 0)
            {

                return ((int)(this.passpoint / 10) - 5) < 0 ?  0 : ((int)(this.passpoint / 10) - 5) ;
            }
            else
            {
                return 0;
            }
        }

        //passpoint 過關分數換算 幾顆星星
        //例: 過關分數 80 / 10 = 8 ; 8 - 5 = 3 *80分就是 = 3顆星
        public string getPasspointStar(int? passpoint)
        {
            if(passpoint != null && passpoint > 0)
            {
                passpoint = (int)(this.passpoint / 10) - 5;
            }

            if (passpoint < 0) {
                passpoint = 0;
            }
           

            string star = "";

            for (int i = 0; i < this.getPasspointStarNumber() ; i++)
            {
                if (i < passpoint)
                {
                    star = star + "★";
                }
                else
                {
                    star = star + "☆";
                }
            }

            return star;
        }
    }
}