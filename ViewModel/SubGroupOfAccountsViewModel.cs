using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SubGroupOfAccountsViewModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string SubGroupDescription { get; set; } = string.Empty;
    [Required]
    public int GroupId { get; set; }

    public IEnumerable<SelectListItem> Groups { get; set; } = Enumerable.Empty<SelectListItem>();
}