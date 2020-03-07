using BlazorAppConcept.Contracts;
using BlazorAppConcept.Domains.Data;
using BlazorAppConcept.Domains.Requests;
using BlazorAppConcept.Domains.Responses;
using DNI.Core.Contracts;
using DNI.Core.Contracts.Providers;
using DNI.Core.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomerDto = BlazorAppConcept.Domains.Dtos.Customer;

namespace BlazorAppConcept.Services.RequestHandlers
{
    public class SaveCustomer : IRequestHandler<SaveCustomerRequest, SaveCustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapperProvider _mapperProvider;
        private readonly IEncryptionProvider _encryptionProvider;

        public SaveCustomer(ICustomerService customerService, IMapperProvider mapperProvider, 
            IEncryptionProvider encryptionProvider)
        {
            _customerService = customerService;
            _mapperProvider = mapperProvider;
            _encryptionProvider = encryptionProvider;
        }

        public async Task<SaveCustomerResponse> Handle(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapperProvider.Map<SaveCustomerRequest, CustomerDto>(request);
            var encryptedCustomer = await _encryptionProvider.Encrypt<CustomerDto, Customer>(customer);

            encryptedCustomer = await _customerService.SaveCustomer(encryptedCustomer, cancellationToken);
            customer = await _encryptionProvider.Decrypt<Customer, CustomerDto>(encryptedCustomer);
            return Response.Success<SaveCustomerResponse>(customer);
        }
    }
}
