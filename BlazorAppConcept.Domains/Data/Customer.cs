using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.Data
{
    public class Customer
    {
        public byte[] FirstName { get; set; }
        public byte[] MiddleName { get; set; }
        public byte[] LastName { get; set; }
        public byte[] EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    }
}
