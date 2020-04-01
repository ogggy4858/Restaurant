using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.AspNet.Mvc;
using WebApp.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.UnityMvcActivator), nameof(WebApp.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApp.UnityMvcActivator), nameof(WebApp.UnityMvcActivator.Shutdown))]
namespace WebApp
{
    public static class UnityMvcActivator
    {
        public static void Start()
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}