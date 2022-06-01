using CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManagement.DAL
{
    public class CustomerManagementDbContext : DbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options)
  : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerManagementDbContext).Assembly);
        }
        public DbSet<Customer> Customers { get; }
    }
}
