using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CustomerState
    {
#pragma warning disable CA1034
        public class UpdateCustomerFieldAction  : IAction
        {
            public string PropertyName { get; set; }
            public object Value { get; set; }
        }
    }
}
