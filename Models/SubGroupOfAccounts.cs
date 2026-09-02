
using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class SubGroupOfAccounts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubGroupDescription { get; set; } = string.Empty;

        // Foreign key for the Group entity.   
        [Required]
        public int GroupId { get; set; } = 0;
        // Navigation property for the related GroupOfAccounts entity.
        public GroupOfAccounts GroupOfAccounts { get; set; } = null!;

        // Navigation property for the related ClassOfAccounts entities.
        public ICollection<ClassOfAccounts> ClassesOfAccounts { get; set; } = new List<ClassOfAccounts>();
    }
}