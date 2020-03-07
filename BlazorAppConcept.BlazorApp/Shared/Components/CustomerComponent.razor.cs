using BlazorAppConcept.Domains.States;
using BlazorState;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.BlazorApp.Shared.Components
{
    public class CustomerComponentRazor : BlazorStateComponent
    {
        [Parameter]
        public int CustomerId { get; set; }

        private CustomerState CustomerState => GetState<CustomerState>();

        protected string FirstName => CustomerState.FirstName;
        protected string MiddleName => CustomerState.MiddleName;
        protected string LastName => CustomerState.LastName;
        protected string EmailAddress => CustomerState.EmailAddress;
        protected DateTime DateOfBirth => CustomerState.DateOfBirth;

        protected override Task OnParametersSetAsync()
        {
            Mediator.Send(new CustomerState.RetrieveCustomerAction { 
                CustomerId = CustomerId
            });
            return base.OnParametersSetAsync();
        }

    }
}
