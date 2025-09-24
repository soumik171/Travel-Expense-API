using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Refund
    {
        [Key]
        public int RefundID { get; set; }

        [ForeignKey("Expense")]
        public int? ExpenseID { get; set; }

        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }

        [Column(TypeName = "varchar")]
        public string PaymentMethod { get; set; } // Bank Transfer, Cash, Mobile Banking, Credit Card

        [Column(TypeName = "varchar")]
        public string Status { get; set; } // Pending, Paid, Cancelled

        // Navigation
        public virtual Expense Expense { get; set; }

    }
}
