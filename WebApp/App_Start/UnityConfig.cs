using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Injection;

namespace WebApp.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.AddNewExtension<DependencyExtension>();
            container.RegisterType<Controllers.AccountController>(new InjectionConstructor());
            container.RegisterType<Controllers.RoleController>(new InjectionConstructor());
        }
    }
}