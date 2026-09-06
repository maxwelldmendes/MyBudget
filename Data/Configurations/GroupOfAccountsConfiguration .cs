using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Models;

namespace MyBudget.Data.Configurations
{
    public class GroupOfAccountsConfiguration : IEntityTypeConfiguration<GroupOfAccounts>
    {
        public void Configure(EntityTypeBuilder<GroupOfAccounts> builder)
        {
            // Primary Key Configuration
            builder.HasKey(g => g.Id);

            // Property Configurations
            builder.Property(g => g.GroupDescription)
                   .IsRequired()
                   .HasMaxLength(150); // Set an explicit max length suitable for a description

            builder.Property(g => g.GroupInformation)
                   .IsRequired()
                   .HasMaxLength(500); // Set an explicit max length suitable for detailed information

            // Relationship Configuration
            builder.HasMany(g => g.SubGroupsOfAccounts)
                   .WithOne(s => s.GroupOfAccounts) // Assumes SubGroupOfAccounts has a reference property back to GroupOfAccounts
                   .HasForeignKey(s => s.GroupId) // Assumes SubGroupOfAccounts has a matching foreign key property
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a group will delete its sub-groups
        }
    }
}