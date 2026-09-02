using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.Models;

namespace MyBudget.ViewModel
{
    public class ClassOfAccountsViewModel
    {
        public ClassOfAccounts ClassOfAccounts { get; set; } = new();

        // Torne o campo obrigatório
        // Use int? no ViewModel:
        [Required(ErrorMessage = "Selecione um subgrupo.")]
        public int? SubGroupId { get; set; }

        public IEnumerable<SelectListItem> SubGroups { get; set; } = new List<SelectListItem>();


    }
}