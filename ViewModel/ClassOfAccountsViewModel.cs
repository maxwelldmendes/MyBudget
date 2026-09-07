using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.Models;

namespace MyBudget.ViewModel
{
    public class ClassOfAccountsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Class Code is required.")]
        [Display(Name = "Class Code")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Class Code must be exactly 4 characters.")]
        public string ClassCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Class Description is required.")]
        [Display(Name = "Class Description")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Class Description must be between 15 and 50 characters.")]
        public string ClassDescription { get; set; } = string.Empty;

        // Torne o campo obrigatório
        // Use int? no ViewModel:
        [Required(ErrorMessage = "Choose a subgroup.")]
        [Display(Name = "Sub-group")]
        public int SubGroupId { get; set; }

        public IEnumerable<SelectListItem> SubGroups { get; set; } = [];
    }
}