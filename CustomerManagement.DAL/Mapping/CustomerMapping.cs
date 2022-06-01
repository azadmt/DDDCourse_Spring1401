using CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Mapping
{

    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.NationalCode);
            builder.Property(p => p.BirthDate);
        }
    }

}
