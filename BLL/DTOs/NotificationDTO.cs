﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int NotificationID { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
