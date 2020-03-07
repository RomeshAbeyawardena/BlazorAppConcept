using BlazorAppConcept.Data;
using BlazorAppConcept.Domains.States;
using BlazorAppConcept.Services;
using DNI.Core.Contracts;
using DNI.Core.Contracts.Options;
using DNI.Core.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlazorAppConcept.ServiceBroker
{
    public class AppServiceBroker : ServiceBrokerBase
    {
        public AppServiceBroker()
        {
            DescribeAssemblies = describe => describe
                .GetAssembly<DataServiceRegistration>()
                .GetAssembly<ServiceRegistration>()
                .GetAssembly<CounterState>();
        }

    }
}
