﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry
{
    public class Bootstrapper
    {
        public static Assembly[] LoadAssemblies()
        {
            // assemblies are loaded as they are needed. but I need to load 3 assemblies to build my DI configuration.
            return new[] { Assembly.GetAssembly(typeof(DomainObjects.IMongoEntity)), Assembly.GetAssembly(typeof(BusinessServices.AuthenticationService)), Assembly.GetAssembly(typeof(Data.CustomerRepository)) };
        }

        public static UnityContainer RegisterTypes()
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssemblies(true, LoadAssemblies()),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    PerRequest);
            return container;
        }

        public static Func<Type, LifetimeManager> PerRequest = (x) => new TransientLifetimeManager();

        public static void Initialize()
        {
            var container = RegisterTypes();
            container.RegisterInstance<HttpContextBase>(new HttpContextWrapper(HttpContext.Current));
            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
        }
    }
}