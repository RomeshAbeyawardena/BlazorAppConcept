using BlazorAppConcept.Contracts;
using BlazorAppConcept.Domains.Data;
using DNI.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppConcept.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public async Task<Customer> GetCustomer(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.Find(false, cancellationToken, id);
        }

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
