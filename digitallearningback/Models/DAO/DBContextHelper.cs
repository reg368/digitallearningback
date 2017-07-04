using System.Data.Entity;

namespace digitallearningback.Models.DAO
{
    public class DBContextHelper
    {

        private static readonly yzucsentities context;

        public static yzucsentities getContext()
        {
            return context;
        }

        static DBContextHelper() {
            context = new yzucsentities();
        }
    }
}