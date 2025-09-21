using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RefundRepo : IRepoG<Refund, int, bool>, IRefund
    {
        TravelExpenseContext db;
        public RefundRepo()
        {
            db = new TravelExpenseContext();
        }
        public bool Create(Refund obj)
        {
            db.Refunds.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = db.Refunds.Find(id);
            if (existing == null) return false;
            db.Refunds.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public List<Refund> Get()
        {
            return db.Refunds.ToList();
        }

        public IRefund RefundId(int id)
        {
            var existing = db.Refunds.Find(id);
            if (existing == null) return null;
            return (IRefund)existing;
        }

        public bool Update(Refund obj)
        {
            var existing = db.Refunds.Find(obj.RefundID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
