namespace digitallearningback.Models.DAO
{
    public class DBContextHelper
    {
        private static readonly yzucsEntities context;

        public static yzucsEntities GetContext()
        {
            return context;
        }

        static DBContextHelper()
        {
            context = new yzucsEntities();
        }
    }
}