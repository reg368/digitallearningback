using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Models
{
    public partial class Answer
    {
        public String minimalText()
        {

            if (this.text != null && this.text.Length > 20)
            {
                return this.text.Substring(0, 20) + "...";
            }
            else
            {
                return this.text;
            }
        }
    }
}