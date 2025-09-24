using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RefundDTO
    {
        public int RefundID { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public int ExpenseID { get; set; }
        public string PaymentMethod { get; set; }="Credit Card";

        public string Status { get; set; }="Pending";

    }
}
