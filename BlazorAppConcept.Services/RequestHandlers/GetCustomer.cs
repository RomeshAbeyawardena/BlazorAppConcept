using BlazorAppConcept.Contracts;
using BlazorAppConcept.Domains.Data;
using BlazorAppConcept.Domains.Requests;
using BlazorAppConcept.Domains.Responses;
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
    public class GetCustomer : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IEncryptionProvider _encryptionProvider;

        public GetCustomer(ICustomerService customerService, IEncryptionProvider encryptionProvider)
        {
            _customerService = customerService;
            _encryptionProvider = encryptionProvider;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomer(request.Id, cancellationToken);

            if(customer == null)
                return Response.Failed<GetCustomerResponse>();

            var decryptedCustomer = await _encryptionProvider
                .Decrypt<Customer, CustomerDto>(customer);

            return Response.Success<GetCustomerResponse>(decryptedCustomer);
        }
    }
}
