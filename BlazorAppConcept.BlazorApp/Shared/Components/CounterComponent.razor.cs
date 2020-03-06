using BlazorAppConcept.Domains.States;
using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.BlazorApp.Shared.Components
{
    public class CounterComponentRazor : BlazorStateComponent
    {
        private CounterState CounterState => GetState<CounterState>();

        protected int Count => CounterState.Count;

        protected void IncrementCount()
        {
            Mediator.Send(new CounterState.IncrementCountAction { Amount = 1 });
        }
    }
}
