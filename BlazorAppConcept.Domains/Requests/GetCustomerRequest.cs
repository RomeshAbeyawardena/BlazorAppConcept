using BlazorAppConcept.Domains.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.Requests
{
    public class GetCustomerRequest : IRequest<GetCustomerResponse>
    {
        public int Id { get; set; }
    }
}
