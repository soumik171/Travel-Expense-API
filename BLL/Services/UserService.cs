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
    public class UserService
    {
         static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            return mapper.Map<List<UserDTO>>(data);
        }

        public static UserDetailsDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataId().UserId(id);
            return mapper.Map<UserDetailsDTO>(data);
        }

        public static bool Create(UserDetailsDTO userDto)
        {
            var data = mapper.Map<User>(userDto);
            return DataAccessFactory.UserData().Create(data);
        }

        public static bool Update(UserDetailsDTO userDto)
        {
            var data = mapper.Map<User>(userDto);
            return DataAccessFactory.UserData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }
    }
}

