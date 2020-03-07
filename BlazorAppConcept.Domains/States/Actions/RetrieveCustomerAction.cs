using BlazorAppConcept.Domains.Dtos;
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
        public class RetrieveCustomerAction : IAction
        {
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
        }
    }
}
