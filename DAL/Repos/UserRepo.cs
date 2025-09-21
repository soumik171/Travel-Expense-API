using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : IRepoG<User, int, bool>, IUser

    {
        TravelExpenseContext db;
        public UserRepo()
        {
            db = new TravelExpenseContext();
        }

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
           return db.Users.ToList();
        }

        public bool Update(User obj)
        {
            var ex = db.Users.Find(obj.UserID);
            if (ex == null) return false;
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public User UserId(int id)
        {
            return db.Users.Find(id);
        }
    }
}
