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
    public class ExpenseService
    {
        public static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<ExpenseDTO> Get()
        {
            var data = DataAccessFactory.ExpenseData().Get();
            return mapper.Map<List<ExpenseDTO>>(data);
        }

        public static List<ExpenseDTO> GetByTrip(int tripId)
        {
            var data = DataAccessFactory.ExpenseData().Get()
                          .Where(e => e.TripID == tripId).ToList();
            return mapper.Map<List<ExpenseDTO>>(data);
        }

        public static bool Create(ExpenseDTO expenseDto)
        { 
            var data = mapper.Map<Expense>(expenseDto);
            return DataAccessFactory.ExpenseData().Create(data);
        }

        public static bool Update(ExpenseDTO expenseDto)
        {
            var data = mapper.Map<Expense>(expenseDto);
            return DataAccessFactory.ExpenseData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ExpenseData().Delete(id);
        }
    }
}

