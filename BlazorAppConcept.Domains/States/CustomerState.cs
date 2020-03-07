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
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public override void Initialize()
        {
            Id = default;
            FirstName = default;
            MiddleName = default;
            LastName = default;
            EmailAddress = default;
            DateOfBirth = default;
        }

        public static void UpdateFields(CustomerState state, Customer customer)
        {
            state.Id = customer.Id;
            state.FirstName = customer.FirstName;
            state.MiddleName = customer.MiddleName;
            state.LastName = customer.LastName;
            state.EmailAddress = customer.EmailAddress;
            state.DateOfBirth = customer.DateOfBirth;
        }
    }
}
