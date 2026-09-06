using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class GroupOfAccounts
    {
        public int Id { get; set; }
        public string GroupDescription { get; set; } = string.Empty;
        public string GroupInformation { get; set; } = string.Empty;

        // Navigation property for the related SubGroupOfAccounts entities.
        public virtual ICollection<SubGroupOfAccounts> SubGroupsOfAccounts { get; set; } = new List<SubGroupOfAccounts>();
    }
}