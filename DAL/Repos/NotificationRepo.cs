using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : IRepoG<Notification, int, bool>
    {
        TravelExpenseContext db;    
        public NotificationRepo()
        {
            db = new TravelExpenseContext();
        }
        public bool Create(Notification obj)
        {
            db.Notifications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id) => false;

        public List<Notification> Get()
        {
            return db.Notifications.OrderByDescending(n=>n.CreatedAt).ToList();
        }

        public bool Update(Notification obj) => false;
        
    }
}
