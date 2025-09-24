using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ApprovalDTO
    {
        public int ApprovalID { get; set; }
        public string ApprovalStatus { get; set; } = "Pending";   // Pending / Approved / Rejected
        public int ApprovedBy { get; set; }  //UserID of the approver
        public int ExpenseID { get; set; }
    }
}
