using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string QuickbooksId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; }
        public string Memo { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
    }
}