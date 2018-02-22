using S2Games.Web.Mappers;
using System.Web.Mvc;
using System.Web.Routing;

namespace S2Games.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
