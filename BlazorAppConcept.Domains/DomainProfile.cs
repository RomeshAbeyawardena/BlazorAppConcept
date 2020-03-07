using AutoMapper;
using BlazorAppConcept.Domains.Data;
using BlazorAppConcept.Domains.Requests;
using BlazorAppConcept.Domains.States;
using System;
using CustomerDto = BlazorAppConcept.Domains.Dtos.Customer;
namespace BlazorAppConcept.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CustomerState, SaveCustomerRequest>();
            CreateMap<SaveCustomerRequest, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
