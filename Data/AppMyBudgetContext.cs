//Aqui criamos a o contexto de acesso ao banco de dados. Cada DbSet refere-se a uma tabela no banco.

using System.Reflection;
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
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLineItem> BillLineItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Automatically finds and applies all implementations of IEntityTypeConfiguration in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}