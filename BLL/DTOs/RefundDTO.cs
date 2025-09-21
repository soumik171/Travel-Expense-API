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
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
