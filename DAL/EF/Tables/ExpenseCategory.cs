using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class ExpenseCategory
    {
      
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        public string CategoryName { get; set; }

        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        // Navigation
        public virtual ICollection<Expense> Expenses { get; set; }
    }

}
