using AccountManagement.Domain.BankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Persistence.EF.Mapping
{
    public class BankAccountMapping : IEntityTypeConfiguration<BankAccountAggregate>
    {
        public void Configure(EntityTypeBuilder<BankAccountAggregate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Changes);
            builder.OwnsOne(p => p.Number);
            builder.OwnsOne(p => p.Balance);
            builder.Property(p => p.OwnerId);
            builder.Property(p => p.Type);
        }
    }
}
