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
        public class SaveCustomerHandler : ActionHandler<SaveCustomerAction>
        {
            private readonly IMediator _mediator;
            private readonly IMapperProvider _mapperProvider;

            public SaveCustomerHandler(IStore aStore, IMediator mediator, IMapperProvider mapperProvider) : base(aStore)
            {
                _mediator = mediator;
                _mapperProvider = mapperProvider;
            }

            CustomerState CustomerState => Store.GetState<CustomerState>();

            public override async Task<Unit> Handle(SaveCustomerAction aAction, CancellationToken aCancellationToken)
            {
                var request = _mapperProvider.Map<CustomerState, SaveCustomerRequest>(CustomerState);
                var response = await _mediator.Send(request);

                if(Response.IsSuccessful(response))
                    UpdateFields(CustomerState, response.Result);

                return Unit.Value;
            }
        }
    }
}
