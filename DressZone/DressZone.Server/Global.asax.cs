using DressZone.Server.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DressZone.Server.Infrastructure.Mapping;
using System.Reflection;

namespace DressZone.Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            DbConfig.Init();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapper = new AutoMapperConfig();
            automapper.Execute(Assembly.GetExecutingAssembly());
            
        }
    }
}
