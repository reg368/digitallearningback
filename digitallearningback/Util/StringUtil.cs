using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitallearningback.Util
{
    public class StringUtil
    {
        /**
         * getContactString(str[1,2,3,4],".")
         * 回傳 1.2.3.4
         * */
        public static String getContactString(IEnumerable<String> strs,String dot) {

            if (strs != null)
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i <  strs.Count(); i++)
                {
                    if (i < (strs.Count() - 1)) {
                        sb.Append(strs.ElementAt(i) + dot);
                    }
                    else
                    {
                        sb.Append(strs.ElementAt(i));
                    }
                }

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}