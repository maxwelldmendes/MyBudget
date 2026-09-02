//Aqui criamos a o contexto de acesso ao banco de dados. Cada DbSet refere-se a uma tabela no banco.

using Microsoft.EntityFrameworkCore;
using MyBudget.Models;

namespace MyBudget.Data
{
    public class AppMyBudgetContext : DbContext
    {
        public AppMyBudgetContext(DbContextOptions<AppMyBudgetContext> options) : base(options)
        { }

        public DbSet<ClassOfAccounts> ClassesOfAccount { get; set; }
        public DbSet<GroupOfAccounts> GroupOfAccounts { get; set; }
        public DbSet<SubGroupOfAccounts> SubGroupOfAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubGroupOfAccounts>()
                .HasOne(g => g.GroupOfAccounts)
                .WithMany(s => s.SubGroupsOfAccounts)
                .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<ClassOfAccounts>()
                .HasOne(c => c.SubGroupOfAccounts)
                .WithMany(s => s.ClassesOfAccounts)
                .HasForeignKey(c => c.SubGroupId);
        }
    }
}