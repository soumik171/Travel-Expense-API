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
    public class TripService
    {
        public static Mapper mapper = AutoMapperConfig.GetMapper();

        public static List<TripDTO> Get()
        {
            var data = DataAccessFactory.TripData().Get();
            return mapper.Map<List<TripDTO>>(data);
        }

        public static TripDetailsDTO GetId(int id)
        {
            var data = DataAccessFactory.TripDataIdName().GetTripId(id);
            return mapper.Map<TripDetailsDTO>(data);
        }
        public static TripDetailsDTO GetName(string name)
        {
            var data = DataAccessFactory.TripDataIdName().GetTripName(name);
            return mapper.Map<TripDetailsDTO>(data);
        }

        public static bool Create(TripDetailsDTO tripDto)
        {
            var data = mapper.Map<Trip>(tripDto);
            return DataAccessFactory.TripData().Create(data);
        }

        public static bool Update(TripDetailsDTO tripDto)
        {
            var data = mapper.Map<Trip>(tripDto);
            return DataAccessFactory.TripData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TripData().Delete(id);
        }
    }
}

