using AutoMapper;
using BLL.DTOs;
using BLL.Mapping;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NotificationService
    {
        static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationData().Get();
            return mapper.Map<List<NotificationDTO>>(data);
        }

        public static bool Create(string message)
        {
            var notification = new Notification { Message = message };
            return DataAccessFactory.NotificationData().Create(notification);
        }
    }
}
