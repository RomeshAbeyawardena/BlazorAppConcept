using BlazorAppConcept.Domains.States;
using BlazorState;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CounterState
    {
        public class IncrementCountHandler : ActionHandler<IncrementCountAction>
        {
            public IncrementCountHandler(IStore aStore) : base(aStore)
            {
            }

            CounterState CounterState => Store.GetState<CounterState>();

            public override Task<Unit> Handle(IncrementCountAction aAction, CancellationToken aCancellationToken)
            {
                CounterState.Count += aAction.Amount;
                return Unit.Task;
            }
        }
    }
}
