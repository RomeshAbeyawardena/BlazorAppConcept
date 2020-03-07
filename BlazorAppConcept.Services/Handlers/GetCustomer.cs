using BlazorAppConcept.Contracts;
using BlazorAppConcept.Domains.Dtos;
using BlazorAppConcept.Domains.Requests;
using BlazorAppConcept.Domains.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppConcept.Services.Handlers
{
    public class GetCustomer : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly ICustomerService _customerService;

        public GetCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetCustomer(request.Id);

            return new GetCustomerResponse { Customer = customer };
        }
    }
}
