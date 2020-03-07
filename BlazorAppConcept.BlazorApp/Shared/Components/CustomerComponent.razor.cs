using BlazorAppConcept.Domains.States;
using BlazorState;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

        protected async Task UpdateCustomerField(string propertyName, object value)
        {
            await Mediator.Send(new CustomerState.UpdateCustomerFieldAction { PropertyName = propertyName, Value = value });
        }

        protected override async Task OnParametersSetAsync()
        {
            await Mediator.Send(new CustomerState.RetrieveCustomerAction { 
                CustomerId = CustomerId
            });
        }

    }
}
