using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using BlazorState.Services;
using BlazorState;

namespace BlazorAppConcept.Services
{
    public class ServiceRegistration : IServiceRegistration

    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services.Scan(scan => scan
            .FromAssemblyOf<ServiceRegistration>()
            .AddClasses()
            .AsImplementedInterfaces());
        }
    }
}
