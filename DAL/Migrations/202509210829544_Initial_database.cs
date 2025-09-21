namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approvals",
                c => new
                    {
                        ApprovalID = c.Int(nullable: false, identity: true),
                        ExpenseID = c.Int(),
                        ApprovedBy = c.Int(),
                        ApprovalStatus = c.String(maxLength: 8000, unicode: false),
                        Comments = c.String(maxLength: 8000, unicode: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Expense_ExpenseID = c.Int(),
                    })
                .PrimaryKey(t => t.ApprovalID)
                .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseID)
                .ForeignKey("dbo.Users", t => t.ApprovedBy)
                .ForeignKey("dbo.Expenses", t => t.ExpenseID)
                .Index(t => t.ExpenseID)
                .Index(t => t.ApprovedBy)
                .Index(t => t.Expense_ExpenseID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Role = c.String(maxLength: 8000, unicode: false),
                        Department = c.String(maxLength: 8000, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        TripID = c.Int(),
                        UserID = c.Int(),
                        CategoryID = c.Int(),
                        ExpenseDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        ReceiptFilePath = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(maxLength: 8000, unicode: false),
                        Approval_ApprovalID = c.Int(),
                        Refund_RefundID = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Approvals", t => t.Approval_ApprovalID)
                .ForeignKey("dbo.ExpenseCategories", t => t.CategoryID)
                .ForeignKey("dbo.Refunds", t => t.Refund_RefundID)
                .ForeignKey("dbo.Trips", t => t.TripID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.TripID)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID)
                .Index(t => t.Approval_ApprovalID)
                .Index(t => t.Refund_RefundID);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Refunds",
                c => new
                    {
                        RefundID = c.Int(nullable: false, identity: true),
                        ExpenseID = c.Int(),
                        RefundAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RefundDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(maxLength: 8000, unicode: false),
                        Expense_ExpenseID = c.Int(),
                    })
                .PrimaryKey(t => t.RefundID)
                .ForeignKey("dbo.Expenses", t => t.ExpenseID)
                .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseID)
                .Index(t => t.ExpenseID)
                .Index(t => t.Expense_ExpenseID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        TripName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Destination = c.String(maxLength: 8000, unicode: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 8000, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TripID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Approvals", "ExpenseID", "dbo.Expenses");
            DropForeignKey("dbo.Approvals", "ApprovedBy", "dbo.Users");
            DropForeignKey("dbo.Expenses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Expenses", "TripID", "dbo.Trips");
            DropForeignKey("dbo.Trips", "UserID", "dbo.Users");
            DropForeignKey("dbo.Refunds", "Expense_ExpenseID", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "Refund_RefundID", "dbo.Refunds");
            DropForeignKey("dbo.Refunds", "ExpenseID", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "CategoryID", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Approvals", "Expense_ExpenseID", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "Approval_ApprovalID", "dbo.Approvals");
            DropIndex("dbo.Trips", new[] { "UserID" });
            DropIndex("dbo.Refunds", new[] { "Expense_ExpenseID" });
            DropIndex("dbo.Refunds", new[] { "ExpenseID" });
            DropIndex("dbo.Expenses", new[] { "Refund_RefundID" });
            DropIndex("dbo.Expenses", new[] { "Approval_ApprovalID" });
            DropIndex("dbo.Expenses", new[] { "CategoryID" });
            DropIndex("dbo.Expenses", new[] { "UserID" });
            DropIndex("dbo.Expenses", new[] { "TripID" });
            DropIndex("dbo.Approvals", new[] { "Expense_ExpenseID" });
            DropIndex("dbo.Approvals", new[] { "ApprovedBy" });
            DropIndex("dbo.Approvals", new[] { "ExpenseID" });
            DropTable("dbo.Trips");
            DropTable("dbo.Refunds");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Expenses");
            DropTable("dbo.Users");
            DropTable("dbo.Approvals");
        }
    }
}
