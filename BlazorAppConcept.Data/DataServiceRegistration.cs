using BlazorAppConcept.Domains;
using BlazorAppConcept.Domains.Data;
using DNI.Core.Contracts;
using DNI.Core.Contracts.Options;
using DNI.Core.Services;
using DNI.Core.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Data
{
    public class DataServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services.RegisterDbContextRepositories<CrmDbContext>(config => {
                config.DbContextServiceProviderOptions = BuildDbContextServiceProviderOptions;
                config.ServiceLifetime = ServiceLifetime.Transient;
                config.DescribedTypes = TypesDescriptor.Describe<Customer>();
            });
        }

        private void BuildDbContextServiceProviderOptions(IServiceProvider serviceProvider, DbContextOptionsBuilder builder)
        {
            var applicationSettings = serviceProvider.GetRequiredService<ApplicationSettings>();
            builder.UseSqlServer(applicationSettings.DefaultConnectionString);
        }
    }
}
