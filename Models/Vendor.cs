using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string QuickbooksId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public bool Is1099Eligible { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public string Terms { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}