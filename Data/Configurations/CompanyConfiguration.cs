using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MyBudget.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LegalName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PrimaryEmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PrimaryPhone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.WebAddress).IsRequired().HasMaxLength(2048);
            builder.Property(e => e.MetaDataCreateTime).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.MetaDataLastUpdatedTime).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

            // Strict One-to-One: Company Address
            builder.HasOne(c => c.CompanyAddress)
                   .WithOne() // Left empty because Address doesn't map backwards
                   .HasForeignKey<Company>(c => c.CompanyAddressId) // Enforces uniqueness on this foreign key
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            // Strict One-to-One: Legal Address
            builder.HasOne(c => c.LegalAddress)
                   .WithOne() // Left empty because Address doesn't map backwards
                   .HasForeignKey<Company>(c => c.LegalAddressId) // Enforces uniqueness on this foreign key
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}