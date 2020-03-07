using DNI.Core.Contracts;
using DNI.Core.Contracts.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using BlazorState.Services;
using BlazorState;
using DNI.Core.Contracts.Providers;
using BlazorAppConcept.Domains;
using System.Collections.Generic;
using DNI.Core.Services.Extensions;
using System.Text;
using EncryptionKeyConstants = BlazorAppConcept.Domains.Constants.EncryptionKey;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BlazorAppConcept.Services
{
    public class ServiceRegistration : IServiceRegistration

    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .RegisterCryptographicCredentialsFactory<AppCryptographicCredentials>(RegisterCryptographicCredentialsFactory)
                .Scan(scan => scan
            .FromAssemblyOf<ServiceRegistration>()
            .AddClasses()
            .AsImplementedInterfaces());
        }

        
        private void RegisterCryptographicCredentialsFactory(ISwitch<string, ICryptographicCredentials> factory, 
            ICryptographyProvider cryptographyProvider, IServiceProvider services)
        {
            var applicationSettings = services.GetRequiredService<ApplicationSettings>();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.IdentificationData, out var identificationEncryptionKey))
                throw new KeyNotFoundException();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.PersonalData, out var personalDataEncryptionKey))
                throw new KeyNotFoundException();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.Default, out var defaultDataEncryptionKey))
                throw new KeyNotFoundException();


            factory
                .CaseWhen(EncryptionKeyConstants.Default,
                    cryptographyProvider.GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512,
                    Encoding.UTF8, defaultDataEncryptionKey.Password, defaultDataEncryptionKey.Salt,
                        defaultDataEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize,
                        Convert.FromBase64String(defaultDataEncryptionKey.InitialVector)))
                .CaseWhen(EncryptionKeyConstants.IdentificationData, 
                    cryptographyProvider
                        .GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512, 
                            Encoding.UTF8, identificationEncryptionKey.Password, identificationEncryptionKey.Salt, 
                            identificationEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize, 
                            Convert.FromBase64String(identificationEncryptionKey.InitialVector)))
                .CaseWhen(EncryptionKeyConstants.PersonalData, 
                    cryptographyProvider
                        .GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512, 
                            Encoding.UTF8, personalDataEncryptionKey.Password, personalDataEncryptionKey.Salt, 
                            personalDataEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize, 
                            Convert.FromBase64String(personalDataEncryptionKey.InitialVector)));
        }
    }
}
