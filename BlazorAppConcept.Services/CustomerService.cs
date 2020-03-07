using BlazorAppConcept.Contracts;
using BlazorAppConcept.Domains.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<Customer> GetCustomer(int id)
        {
            return Task.FromResult(new Customer
            {
                Id = id,
                EmailAddress = "Jane.Doe@gmail.com",
                FirstName = "Jane",
                MiddleName = "Harrison",
                LastName = "Doe",
                DateOfBirth = new DateTime(1987, 07, 01)
            });
        }
    }
}
