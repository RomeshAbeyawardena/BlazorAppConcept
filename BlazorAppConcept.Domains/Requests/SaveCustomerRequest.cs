using BlazorAppConcept.Domains.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.Requests
{
    public class SaveCustomerRequest : IRequest<SaveCustomerResponse>
    {
        public int Id { get;  set; }
        public string FirstName { get;  set; }
        public string MiddleName { get;  set; }
        public string LastName { get;  set; }
        public string EmailAddress { get;  set; }
        public DateTime DateOfBirth { get;  set; }

    }
}
