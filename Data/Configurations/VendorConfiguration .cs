

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

namespace MyBudget.Data.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(e => e.VendorId);
            builder.Property(e => e.QuickbooksId).HasMaxLength(50);
            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.TaxId).HasMaxLength(20);
            builder.Property(e => e.AccountNumber).HasMaxLength(50);
            builder.Property(e => e.Terms).HasMaxLength(50);
            builder.Property(e => e.CurrentBalance).HasColumnType("decimal(18,2)");
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(v => v.BillingAddress)
                   .WithMany()
                   .HasForeignKey(v => v.BillingAddressId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
