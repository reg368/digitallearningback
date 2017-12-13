using System.Web.Mvc;

namespace digitallearningback.Areas.Game
{
    public class GameAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Game";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Game_default",
                "Game/{controller}/{action}/{id}",
                new { controller = "Play", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}