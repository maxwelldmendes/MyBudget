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
        public string QuickbooksId { get; set; }
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TaxId { get; set; }
        public bool Is1099Eligible { get; set; }
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Terms { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}