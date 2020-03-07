using BlazorAppConcept.Domains.Dtos;
using BlazorAppConcept.Domains.Requests;
using BlazorState;
using DNI.Core.Contracts;
using DNI.Core.Domains;
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
        #pragma warning disable CA1034
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

                if(Response.IsSuccessful(response))
                    UpdateFields(CustomerState, response.Result);
                
                return Unit.Value;
            }
        }
        #pragma warning restore CA1034
    }
}
