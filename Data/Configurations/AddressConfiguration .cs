
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

namespace MyBudget.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.AddressId);
            builder.Property(e => e.Street1).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Street2).HasMaxLength(100);
            builder.Property(e => e.City).IsRequired().HasMaxLength(50);
            builder.Property(e => e.State).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PostalCode).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Country).IsRequired().HasMaxLength(50).HasDefaultValue("USA");
        }

    }
}