using BlazorAppConcept.Domains.Data;
using DNI.Core.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorAppConcept.Data
{
    public class CrmDbContext : DbContextBase
    {
        public CrmDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions, true, true, true)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
