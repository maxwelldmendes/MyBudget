
using System.ComponentModel.DataAnnotations;


namespace MyBudget.ViewModel
{
    public class SubGroupOfAccountsViewModel
    {
        public int Id { get; set; }
        public string SubGroupDescription { get; set; } = string.Empty;
        // Foreign key for the Group entity.   
        public int GroupId { get; set; }

        // Navigation properties
        public GroupOfAccountsViewModel GroupOfAccountsVM { get; set; } = new GroupOfAccountsViewModel();

        public virtual ICollection<ClassOfAccountsViewModel> ClassesOfAccounts { get; set; } = new List<ClassOfAccountsViewModel>();
    }
}