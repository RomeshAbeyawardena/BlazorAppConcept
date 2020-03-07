using BlazorAppConcept.Domains.Dtos;
using BlazorAppConcept.Domains.Requests;
using BlazorState;
using DNI.Shared.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CustomerState
    {
        public class RetrieveCustomerHandler : ActionHandler<RetrieveCustomerAction>
        {
            private readonly IMediator _mediator;

            public RetrieveCustomerHandler(IStore aStore, IMediator mediator) : base(aStore)
            {
                _mediator = mediator;
            }

            CustomerState CustomerState => Store.GetState<CustomerState>();

            public override async Task<Unit> Handle(RetrieveCustomerAction aAction, CancellationToken aCancellationToken)
            {
                var response = await _mediator.Send(new GetCustomerRequest { Id = aAction.CustomerId });

                CustomerState.FirstName = response.Customer.FirstName;
                CustomerState.MiddleName = response.Customer.MiddleName;
                CustomerState.LastName = response.Customer.LastName;
                CustomerState.EmailAddress = response.Customer.EmailAddress;
                CustomerState.DateOfBirth = response.Customer.DateOfBirth;

                return Unit.Value;
            }
        }
    }
}
