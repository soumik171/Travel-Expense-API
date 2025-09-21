using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ExpenseCategoryRepo : IRepoG<ExpenseCategory, int, bool>
    {
        TravelExpenseContext db;
        public ExpenseCategoryRepo()
        {
            db = new TravelExpenseContext();
        }

        public bool Create(ExpenseCategory obj)
        {
            db.ExpenseCategories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = db.ExpenseCategories.Find(id);
            if (existing == null) return false;
            db.ExpenseCategories.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public List<ExpenseCategory> Get()
        {
            return db.ExpenseCategories.ToList();
        }

        public bool Update(ExpenseCategory obj)
        {
            var existing = db.ExpenseCategories.Find(obj.CategoryID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
