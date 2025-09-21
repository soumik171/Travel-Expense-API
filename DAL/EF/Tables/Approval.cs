using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Approval
    {
        [Key]
        public int ApprovalID { get; set; }

        [ForeignKey("Expense")]
        public int? ExpenseID { get; set; }

        [ForeignKey("Approver")]
        public int? ApprovedBy { get; set; }   // UserID (Manager/Admin)

        [Column(TypeName = "varchar")]
        public string ApprovalStatus { get; set; } // Pending, Approved, Rejected

        [Column(TypeName = "varchar")]
        public string Comments { get; set; }

        public DateTime ApprovalDate { get; set; } = DateTime.Now;

        // Navigation
        public virtual Expense Expense { get; set; }
        public virtual User Approver { get; set; }
    }
}

