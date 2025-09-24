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
    public class ExpenseCategoryService
    {
        private static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<ExpenseCategoryDTO> Get()
        {
            var data = DataAccessFactory.ExpenseCategoryData().Get();
            return mapper.Map<List<ExpenseCategoryDTO>>(data);
        }

        public static bool Create(ExpenseCategoryDTO categoryDto)
        {
            var data = mapper.Map<ExpenseCategory>(categoryDto);
            return DataAccessFactory.ExpenseCategoryData().Create(data);
        }

        public static bool Update(ExpenseCategoryDTO categoryDto)
        {
            var data = mapper.Map<ExpenseCategory>(categoryDto);
            return DataAccessFactory.ExpenseCategoryData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ExpenseCategoryData().Delete(id);
        }
    }
    
}
