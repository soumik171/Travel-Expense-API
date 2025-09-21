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
    public class RefundService
    {
        public static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<RefundDTO> Get()
        {
            var data = DataAccessFactory.RefundData().Get();
            return mapper.Map<List<RefundDTO>>(data);
        }

        public static bool Create(RefundDetailsDTO refundDto)
        {
            var data = mapper.Map<Refund>(refundDto);
            return DataAccessFactory.RefundData().Create(data);
        }

        public static bool Update(RefundDetailsDTO refundDto)
        {
            var data = mapper.Map<Refund>(refundDto);
            return DataAccessFactory.RefundData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.RefundData().Delete(id);
        }
    }
}
