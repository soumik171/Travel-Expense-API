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

        public static TripDTO GetId(int id)
        {
            var data = DataAccessFactory.TripDataIdName().GetTripId(id);
            return mapper.Map<TripDTO>(data);
        }
        public static TripDTO GetName(string name)
        {
            var data = DataAccessFactory.TripDataIdName().GetTripName(name);
            return mapper.Map<TripDTO>(data);
        }

        public static bool Create(TripDTO tripDto)
        {
            var data = mapper.Map<Trip>(tripDto);
            return DataAccessFactory.TripData().Create(data);
        }

        public static bool Update(TripDTO tripDto)
        {
            var data = mapper.Map<Trip>(tripDto);
            return DataAccessFactory.TripData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TripData().Delete(id);
        }

        //Recommendation method based on trip ID
        public static List<TripDTO> RecommendByTripId(int tripId)
        {
            var baseTrip = GetId(tripId);
            if (baseTrip == null) return new List<TripDTO>();   // Get current trip

            var allTrips = Get();   //Get all trips

            var recommendations = allTrips
                .Where(t => t.TripID != tripId &&
                            t.Destination == baseTrip.Destination)  //only the same destination
                .ToList();

            return recommendations;
        }

        public static List<TripDTO> RecommendByDestination(string destination)
        {
            var allTrips = Get();   // Already mapped list of TripDTOs

            var recommendations = allTrips
                .Where(t => t.Destination == destination) // Skip same destination
                .ToList();

            return recommendations;
        }


    }
}

