using BlazorAppConcept.Domains.States;
using BlazorAppConcept.Services;
using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using DNI.Shared.Services.Abstraction;
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
            Assemblies = new [] { DefaultAssembly, GetAssembly<ServiceRegistration>(), GetAssembly<CounterState>() };
        }

    }
}
