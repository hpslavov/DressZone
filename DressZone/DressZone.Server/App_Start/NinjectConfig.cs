[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DressZone.Server.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DressZone.Server.App_Start.NinjectConfig), "Stop")]

namespace DressZone.Server.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Repository.Contracts;
    using Context.Contracts;
    using Context;
    public static class NinjectConfig 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDressZoneDbContext>().To<DressZoneDbContext>().InRequestScope();

            kernel.Bind(x =>
            {
                x.From("DressZone.Services")
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.From("DressZone.Repository")
                .SelectAllClasses()
                .BindDefaultInterface();
            });
        }        
    }
}
