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
        public string ClassCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Class Description is required.")]
        [Display(Name = "Class Description")]
        public string ClassDescription { get; set; } = string.Empty;

        // Torne o campo obrigatório
        // Use int? no ViewModel:
        [Required(ErrorMessage = "Choose a subgroup.")]
        [Display(Name = "Sub-group")]
        public int SubGroupId { get; set; }

        public IEnumerable<SelectListItem> SubGroups { get; set; } = [];
    }
}