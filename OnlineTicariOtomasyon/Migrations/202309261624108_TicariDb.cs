namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicariDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 10, unicode: false),
                        Password = c.String(maxLength: 10, unicode: false),
                        Authority = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        BillSerialNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        BillSequenceNo = c.String(maxLength: 6, unicode: false),
                        Date = c.DateTime(nullable: false),
                        TaxAdministration = c.String(maxLength: 60, unicode: false),
                        Clock = c.DateTime(nullable: false),
                        Deliverer = c.String(maxLength: 30, unicode: false),
                        DeliveryArea = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.BillID);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Amount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bill_BillID = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKalemID)
                .ForeignKey("dbo.Bills", t => t.Bill_BillID)
                .Index(t => t.Bill_BillID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30, unicode: false),
                        ProductBrand = c.String(maxLength: 30, unicode: false),
                        ProductStock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 250, unicode: false),
                        Category_CategoryID = c.Int(),
                        SalesStatus_SalesStatusID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.SalesStatus", t => t.SalesStatus_SalesStatusID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.SalesStatus_SalesStatusID);
            
            CreateTable(
                "dbo.SalesStatus",
                c => new
                    {
                        SalesStatusID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Piece = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesStatusID);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        CurrentID = c.Int(nullable: false, identity: true),
                        CurrentName = c.String(maxLength: 30, unicode: false),
                        CurrentSurname = c.String(maxLength: 30, unicode: false),
                        CurrentCity = c.String(maxLength: 13, unicode: false),
                        CurrentMail = c.String(maxLength: 50, unicode: false),
                        SalesStatus_SalesStatusID = c.Int(),
                    })
                .PrimaryKey(t => t.CurrentID)
                .ForeignKey("dbo.SalesStatus", t => t.SalesStatus_SalesStatusID)
                .Index(t => t.SalesStatus_SalesStatusID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 30, unicode: false),
                        EmployeeSurname = c.String(maxLength: 30, unicode: false),
                        EmployeeImage = c.String(maxLength: 250, unicode: false),
                        Department_DepartmentID = c.Int(),
                        SalesStatus_SalesStatusID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .ForeignKey("dbo.SalesStatus", t => t.SalesStatus_SalesStatusID)
                .Index(t => t.Department_DepartmentID)
                .Index(t => t.SalesStatus_SalesStatusID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenceID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropForeignKey("dbo.Employees", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropForeignKey("dbo.Employees", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Currents", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.FaturaKalems", "Bill_BillID", "dbo.Bills");
            DropIndex("dbo.Employees", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Employees", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Currents", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Products", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropIndex("dbo.FaturaKalems", new[] { "Bill_BillID" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Currents");
            DropTable("dbo.SalesStatus");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Bills");
            DropTable("dbo.Admins");
        }
    }
}
