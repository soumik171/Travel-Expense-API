using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ExpenseDetailsDTO
    {
        public int UserID { get; set; }
        public int TripID { get; set; }
        public int CategoryID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
