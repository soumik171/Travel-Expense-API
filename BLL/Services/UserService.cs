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

        public UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataId().UserId(id);
            return mapper.Map<UserDTO>(data);
        }

        public bool Create(UserDTO userDto)
        {
            var data = mapper.Map<User>(userDto);
            var created = DataAccessFactory.UserData().Create(data);

            // If successfully creates data, it stored in the notification table
            if (created)
            {
                NotificationService.Create($"{userDto.FullName} is added. ");
            }
            return created;
        }

        public bool Update(UserDTO userDto)
        {
            var data = mapper.Map<User>(userDto);
            return DataAccessFactory.UserData().Update(data);
        }

        public bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }

    }
}

