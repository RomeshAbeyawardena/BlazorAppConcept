using BlazorState;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CustomerState
    {
#pragma warning disable CA1034
        public class UpdateCustomerFieldHandler : ActionHandler<UpdateCustomerFieldAction>
        {
            
            public UpdateCustomerFieldHandler(IStore aStore) : base(aStore)
            {
                
            }

            CustomerState CustomerState => Store.GetState<CustomerState>();

            public override Task<Unit> Handle(UpdateCustomerFieldAction aAction, CancellationToken aCancellationToken)
            {
                var prop = CustomerState.GetType().GetProperty(aAction.PropertyName);

                prop.SetValue(CustomerState, Convert.ChangeType(aAction.Value, prop.PropertyType));
                return Unit.Task;
            }
        }
#pragma warning restore CA1034
    }
}
