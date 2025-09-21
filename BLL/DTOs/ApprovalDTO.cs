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
        public string Status { get; set; }   // Pending / Approved / Rejected
        public int ExpenseID { get; set; }
        public string ExpenseDescription { get; set; }
    }
}
