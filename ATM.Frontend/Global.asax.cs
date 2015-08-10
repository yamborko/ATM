using Ninject.Web.Mvc;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ATM.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterMap();
        }

        private static void RegisterMap()
        {
            DependencyResolver.SetResolver(
                new NinjectDependencyResolver(
                        NinjectWrapper.NinjectKernel));

            NinjectWrapper.NinjectKernel.Bind(
                x => x.From("ATM.Frontend.Model")
                      .SelectAllClasses()
                      .BindAllInterfaces());
        }
    }
}
