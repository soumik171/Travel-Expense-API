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

        public static bool Create(ExpenseDetailsDTO expenseDto)
        {
            var data = mapper.Map<Expense>(expenseDto);
            return DataAccessFactory.ExpenseData().Create(data);
        }

        public static bool Update(ExpenseDetailsDTO expenseDto)
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

