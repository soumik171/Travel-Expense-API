using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class TripRepo : IRepoG<Trip, int, bool>, ITrip
    {
        TravelExpenseContext db;
        public TripRepo()
        {
            db = new TravelExpenseContext();
        }
        public bool Create(Trip obj)
        {
            db.Trips.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = db.Trips.Find(id);
            if (existing == null) return false;
            db.Trips.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public List<Trip> Get()
        {
            return db.Trips.ToList();
        }


        public bool Update(Trip obj)
        {
            var existing = db.Trips.Find(obj.TripID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public Trip GetTripId(int id)
        {
            return db.Trips.Find(id);
        }

        public Trip GetTripName(string name)
        {
            return db.Trips.FirstOrDefault(t => t.TripName == name);
        }
    }
}
