using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

namespace MyBudget.Data.Configurations
{
    public class SubGroupOfAccountsConfiguration : IEntityTypeConfiguration<SubGroupOfAccounts>
    {
        public void Configure(EntityTypeBuilder<SubGroupOfAccounts> builder)
        {
            // Primary Key Configuration
            builder.HasKey(s => s.Id);

            // Property Configurations
            builder.Property(s => s.SubGroupDescription)
                   .IsRequired()
                   .HasMaxLength(150); // Set an explicit max length suitable for a description

            // Relationship: Many SubGroups belong to One Group
            builder.HasOne(s => s.GroupOfAccounts)
                   .WithMany(g => g.SubGroupsOfAccounts)
                   .HasForeignKey(s => s.GroupId) // Maps directly to your GroupId field
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a Group deletes its SubGroups

            // Relationship: One SubGroup has Many Classes
            builder.HasMany(s => s.ClassesOfAccounts)
                   .WithOne(c => c.SubGroupOfAccounts) // Assumes ClassOfAccounts has a reference property back
                   .HasForeignKey(c => c.SubGroupId) // Assumes ClassOfAccounts uses SubGroupId as a foreign key
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
