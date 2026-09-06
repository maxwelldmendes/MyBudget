using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

public class InvoiceLineItemConfiguration : IEntityTypeConfiguration<InvoiceLineItem>
{
    public void Configure(EntityTypeBuilder<InvoiceLineItem> builder)
    {
        builder.HasKey(e => e.InvoiceLineItemId);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(200);
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        // Relationships
        builder.HasOne(ili => ili.Invoice)
               .WithMany(i => i.LineItems)
               .HasForeignKey(ili => ili.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}