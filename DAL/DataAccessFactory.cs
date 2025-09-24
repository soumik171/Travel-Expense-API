using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
    public class DataAccessFactory
    {
        public static IRepoG<User, int, bool>  UserData()
        {
            return new UserRepo();
        }

        public static IUser UserDataId()
        {
            return new UserRepo();
        }
        

        public static IRepoG<Trip, int, bool> TripData()
        {
            return new TripRepo();
        }
        public static ITrip TripDataIdName()
        {
            return new TripRepo();
        }

        public static IRepoG<Expense, int, bool> ExpenseData()
        {
            return new ExpenseRepo();
        }

        public static IRepoG<ExpenseCategory, int, bool> ExpenseCategoryData()
        {
            return new ExpenseCategoryRepo();
        }

        public static IRepoG<Approval, int, bool> ApprovalData()
        {
            return new ApprovalRepo();
        }

        public static IRepoG<Refund, int, bool> RefundData()
        {
            return new RefundRepo();
        }
        public static IRefund RefundDataId()
        {
            return new RefundRepo();
        }

        public static IRepoG<Notification,int, bool>NotificationData()
        {
            return new NotificationRepo();
        }

    }
}
