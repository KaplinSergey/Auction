﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;


namespace MvcPL.Infrastructure
{
    public class NinjectMvcDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectMvcDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}