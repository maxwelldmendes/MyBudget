
using System.ComponentModel.DataAnnotations;


namespace MyBudget.ViewModel
{
    public class GroupOfAccountsViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Group name is required.")]
        [Display(Name = "Group Name")]
        public string GroupDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Group information is required.")]
        [Display(Name = "Group Information")]
        public string GroupInformation { get; set; } = string.Empty;

    }
}