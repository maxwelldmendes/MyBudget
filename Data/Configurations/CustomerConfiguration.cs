using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId);
        builder.Property(e => e.QuickbooksId).HasMaxLength(50);
        builder.Property(e => e.CompanyName).HasMaxLength(100);
        builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.CurrentBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

        // Relationships
        builder.HasOne(c => c.BillingAddress)
               .WithMany()
               .HasForeignKey(c => c.BillingAddressId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ShippingAddress)
               .WithMany()
               .HasForeignKey(c => c.ShippingAddressId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}