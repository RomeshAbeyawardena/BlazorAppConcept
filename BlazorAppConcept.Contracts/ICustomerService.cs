using BlazorAppConcept.Domains.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int id);
    }
}
