
using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class SubGroupOfAccounts
    {
        public int Id { get; set; }
        public string SubGroupDescription { get; set; } = string.Empty;
        // Foreign key for the Group entity.   
        public int GroupId { get; set; }

        // Navigation properties
        public virtual GroupOfAccounts GroupOfAccounts { get; set; } = null!;
        public virtual ICollection<ClassOfAccounts> ClassesOfAccounts { get; set; } = new List<ClassOfAccounts>();
    }
}