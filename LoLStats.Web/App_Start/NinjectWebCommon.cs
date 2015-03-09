#region References

using System;
using System.Web;
using LoLStats.Core.Managers;
using LoLStats.Shared.Interfaces;
using LoLStats.Web.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

#endregion

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace LoLStats.Web.App_Start
{
    public static class NinjectWebCommon
    {
        #region Fields

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        #endregion

        #region Methods

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
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
            kernel.Bind<IChampionManager>().To<ChampionManager>();
        }

        #endregion
    }
}