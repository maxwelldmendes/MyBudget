using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

public class BillLineItemConfiguration : IEntityTypeConfiguration<BillLineItem>
{
    public void Configure(EntityTypeBuilder<BillLineItem> builder)
    {
        builder.HasKey(e => e.BillLineItemId);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(200);
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        // Relationships
        builder.HasOne(bli => bli.Bill)
               .WithMany(b => b.LineItems)
               .HasForeignKey(bli => bli.BillId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}