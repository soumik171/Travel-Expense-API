﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
