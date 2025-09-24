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
    public class ApprovalService
    {
        public static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<ApprovalDTO> Get()
        {
            var data = DataAccessFactory.ApprovalData().Get();
            return mapper.Map<List<ApprovalDTO>>(data);
        }

        public static bool Create(ApprovalDTO approvalDto)
        {
            var data = mapper.Map<Approval>(approvalDto);
            return DataAccessFactory.ApprovalData().Create(data);
        }

        public static bool Update(ApprovalDTO approvalDto)
        {
            var data = mapper.Map<Approval>(approvalDto);
            return DataAccessFactory.ApprovalData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ApprovalData().Delete(id);
        }
    }
}
