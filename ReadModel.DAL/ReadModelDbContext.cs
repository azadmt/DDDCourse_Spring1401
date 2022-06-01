using Microsoft.EntityFrameworkCore;
using ReadModel.DAL.DataModel;
using System;

namespace ReadModel.DAL
{
    public class ReadModelDbContext : DbContext
    {
        public ReadModelDbContext(DbContextOptions<ReadModelDbContext> options)
: base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadModelDbContext).Assembly);
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
    }
}
