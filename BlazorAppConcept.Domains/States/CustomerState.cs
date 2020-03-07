using BlazorAppConcept.Domains.Dtos;
using BlazorState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

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
            ResetFields(this);
        }

        public static void UpdateFields(CustomerState state, Customer customer)
        {
            state.Id = customer.Id;
            state.FirstName = customer.FirstName.ToLower().Titleize();
            state.MiddleName = customer.MiddleName.ToLower().Titleize();
            state.LastName = customer.LastName.ToLower().Titleize();
            state.EmailAddress = customer.EmailAddress.ToLower();
            state.DateOfBirth = customer.DateOfBirth;
        }

        public static void ResetFields(CustomerState state)
        {
            state.Id = default;
            state.FirstName = default;
            state.MiddleName = default;
            state.LastName = default;
            state.EmailAddress = default;
            state.DateOfBirth = default;
        }
    }
}
