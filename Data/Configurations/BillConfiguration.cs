using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(e => e.BillId);
        builder.Property(e => e.QuickbooksId).HasMaxLength(50);
        builder.Property(e => e.BillNumber).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Unpaid");
        builder.Property(e => e.Memo).HasMaxLength(500);
        builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.AmountPaid).HasColumnType("decimal(18,2)");

        // Relationships
        builder.HasOne(b => b.Vendor)
               .WithMany(v => v.Bills)
               .HasForeignKey(b => b.VendorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}