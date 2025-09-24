using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ApprovalRepo : IRepoG<Approval, int, bool>
    {
        TravelExpenseContext db;
        public ApprovalRepo()
        {
            db = new TravelExpenseContext();
        }

        public List<Approval> Get()
        {
            return db.Approvals.ToList();
        }

        public bool Create(Approval obj)
        {
            db.Approvals.Add(obj);
            return db.SaveChanges() > 0;

        }

        public bool Update(Approval obj)
        {
            var existing = db.Approvals.Find(obj.ApprovalID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var existing = db.Approvals.Find(id);
            if (existing == null) return false;

            db.Approvals.Remove(existing);
            return db.SaveChanges() > 0;
        }


    }
}
