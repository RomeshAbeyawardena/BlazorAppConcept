using BlazorAppConcept.Domains.Dtos;
using DNI.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.Responses
{
    public class GetCustomerResponse : ResponseBase
    {
        public Customer Customer { get; set; }
    }
}
