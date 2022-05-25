using AccountManagement.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Persistence.EF
{
    public class AccountManagementDbContext : DbContext
    {
        public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options)
        : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountManagementDbContext).Assembly);
        }

    }
}
