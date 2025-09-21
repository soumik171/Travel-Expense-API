using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        public string TripName { get; set; }

        [Column(TypeName = "varchar")]
        public string Destination { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "varchar")]
        public string Status { get; set; }   // Planned, Ongoing, Completed, Cancelled

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public virtual User User { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }

}
