using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(e => e.InvoiceId);
        builder.Property(e => e.QuickbooksId).HasMaxLength(50);
        builder.Property(e => e.InvoiceNumber).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Unpaid");
        builder.Property(e => e.Memo).HasMaxLength(500);
        builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.AmountPaid).HasColumnType("decimal(18,2)");

        // Relationships
        builder.HasOne(i => i.Customer)
               .WithMany(c => c.Invoices)
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}