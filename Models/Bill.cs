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
        public string QuickbooksId { get; set; }
        public string BillNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; }
        public string Memo { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<BillLineItem> LineItems { get; set; } = new List<BillLineItem>();
    }
}