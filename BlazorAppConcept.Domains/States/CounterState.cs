using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CounterState : State<CounterState>
    {
        public int Count { get; private set; }
        public override void Initialize()
        {
            Count = 0;
        }
    }
}
