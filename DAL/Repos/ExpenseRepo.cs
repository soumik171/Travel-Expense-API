using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ExpenseRepo : IRepoG<Expense, int, bool>
    {
        TravelExpenseContext db;
        public ExpenseRepo()
        {
            db = new TravelExpenseContext();
        }

        public bool Create(Expense obj)
        {
           db.Expenses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Expenses.Find(id);
            if (ex == null) return false;
            db.Expenses.Remove(ex);
            return db.SaveChanges() > 0;
        }


        public List<Expense> Get()
        {
            return db.Expenses.ToList();
        }

        public bool Update(Expense obj)
        {
            var ex = db.Expenses.Find(obj.ExpenseID);
            if (ex == null) return false;
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
