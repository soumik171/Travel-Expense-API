using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ExpenseDTO
    {
        public int ExpenseID { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public int TripID { get; set; }
    }
}
