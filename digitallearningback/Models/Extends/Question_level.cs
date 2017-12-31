using digitallearningback.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Question_level
    {

        private Log4Net logger = new Log4Net("Question_level");

        //過關要求幾顆星 
        //例: 設定80分 , 80 / 20 = 4顆星
        public int?  getPasspointStarNumber() {

            if (this.passpoint != null && this.passpoint > 0 )
            {

                return ((int)this.passpoint / 20 );
            }
            else
            {
                return 0;
            }
        }

        //point 過關分數換算 幾顆星星
        //例: 過關分數 80 / 20 = 4 , 4顆星星
        public string getPasspointStar(int? point)
        {
            //logger.debug("getPasspointStar", "init passpoint : "+ passpoint);

            if (point != null && point > 0)
            {
                point = point / 20;
            }

            if (point < 0) {
                point = 0;
            }

            //logger.debug("getPasspointStar", "after calculate passpoint : " + passpoint);

            string star = "";

            for (int i = 0; i < this.getPasspointStarNumber() ; i++)
            {
                if (i < point)
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