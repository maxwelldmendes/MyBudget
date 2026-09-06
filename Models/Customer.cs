using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string QuickbooksId { get; set; }
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }

        public int? ShippingAddressId { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}