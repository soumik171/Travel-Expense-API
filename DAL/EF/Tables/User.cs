using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]

        public string Role { get; set; }   // Employee, Manager, Admin

        [Column(TypeName = "varchar")]
        public string Department { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}

