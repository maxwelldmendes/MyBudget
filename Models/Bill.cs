using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public string QuickbooksId { get; set; } = string.Empty;
        public string BillNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Memo { get; set; } = string.Empty;

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<BillLineItem> LineItems { get; set; } = new List<BillLineItem>();
    }
}