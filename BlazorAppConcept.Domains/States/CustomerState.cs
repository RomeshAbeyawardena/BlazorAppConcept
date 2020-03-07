using BlazorAppConcept.Domains.Dtos;
using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.States
{
    public partial class CustomerState : State<CounterState>
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override void Initialize()
        {
            FirstName = default;
            MiddleName = default;
            LastName = default;
            EmailAddress = default;
            DateOfBirth = default;
        }
    }
}
