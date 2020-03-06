using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CounterState
    {
        public class IncrementCountAction : IAction
        {
            public int Amount { get; set; }
        }
    }
}
