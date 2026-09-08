
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace MyBudget.Models
{
    public class SubGroupOfAccounts
    {
        public int Id { get; set; }
        public string SubGroupDescription { get; set; } = string.Empty;
        // Foreign key for the Group entity.   
        public int GroupId { get; set; }

        // Navigation properties
        public GroupOfAccounts GroupOfAccounts { get; set; } = new GroupOfAccounts();

        public virtual ICollection<ClassOfAccounts> ClassesOfAccounts { get; set; } = new List<ClassOfAccounts>();
    }
}