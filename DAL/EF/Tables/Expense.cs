using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [ForeignKey("Trip")]
        public int? TripID { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }

        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }

        [Column(TypeName = "varchar")]
        public string Currency { get; set; }

        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        public string ReceiptFilePath { get; set; }

        [Column(TypeName = "varchar")]
        public string Status { get; set; }  // Pending, Approved, Rejected

        // Navigation
        public virtual Trip Trip { get; set; }
        public virtual User User { get; set; }
        public virtual ExpenseCategory Category { get; set; }
        public virtual Approval Approval { get; set; }
        public virtual Refund Refund { get; set; }

        public virtual ICollection<Refund> Refunds  { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }


        }
}
