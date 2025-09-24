using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class AutoMapperConfig
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // User
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<User, UserDetailsDTO>().ReverseMap();

                // Trip
                cfg.CreateMap<Trip, TripDTO>().ReverseMap();
                cfg.CreateMap<Trip, TripDetailsDTO>().ReverseMap();

                // Expense
                cfg.CreateMap<Expense, ExpenseDTO>().ReverseMap();
                cfg.CreateMap<Expense, ExpenseDetailsDTO>().ReverseMap();

                // ExpenseCategory
                cfg.CreateMap<ExpenseCategory, ExpenseCategoryDTO>().ReverseMap();
                cfg.CreateMap<ExpenseCategory, ExpenseCategoryDetailsDTO>().ReverseMap();

                // Approval
                cfg.CreateMap<Approval, ApprovalDTO>().ReverseMap();
                cfg.CreateMap<Approval, ApprovalDetailsDTO>().ReverseMap();

                // Refund
                cfg.CreateMap<Refund, RefundDTO>().ReverseMap();
                cfg.CreateMap<Refund, RefundDetailsDTO>().ReverseMap();

                // Notification
                cfg.CreateMap<Notification, NotificationDTO>();
                cfg.CreateMap<NotificationDTO, Notification>();

            });

            return new Mapper(config);
        }
    }
}

