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
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
