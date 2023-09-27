namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Currents", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Employees", new[] { "SalesStatus_SalesStatusID" });
            RenameColumn(table: "dbo.SalesStatus", name: "SalesStatus_SalesStatusID", newName: "Product_ProductID");
            RenameColumn(table: "dbo.SalesStatus", name: "SalesStatus_SalesStatusID", newName: "Current_CurrentID");
            RenameColumn(table: "dbo.SalesStatus", name: "SalesStatus_SalesStatusID", newName: "Employee_EmployeeID");
            CreateIndex("dbo.SalesStatus", "Current_CurrentID");
            CreateIndex("dbo.SalesStatus", "Employee_EmployeeID");
            CreateIndex("dbo.SalesStatus", "Product_ProductID");
            DropColumn("dbo.Products", "SalesStatus_SalesStatusID");
            DropColumn("dbo.Currents", "SalesStatus_SalesStatusID");
            DropColumn("dbo.Employees", "SalesStatus_SalesStatusID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "SalesStatus_SalesStatusID", c => c.Int());
            AddColumn("dbo.Currents", "SalesStatus_SalesStatusID", c => c.Int());
            AddColumn("dbo.Products", "SalesStatus_SalesStatusID", c => c.Int());
            DropIndex("dbo.SalesStatus", new[] { "Product_ProductID" });
            DropIndex("dbo.SalesStatus", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.SalesStatus", new[] { "Current_CurrentID" });
            RenameColumn(table: "dbo.SalesStatus", name: "Employee_EmployeeID", newName: "SalesStatus_SalesStatusID");
            RenameColumn(table: "dbo.SalesStatus", name: "Current_CurrentID", newName: "SalesStatus_SalesStatusID");
            RenameColumn(table: "dbo.SalesStatus", name: "Product_ProductID", newName: "SalesStatus_SalesStatusID");
            CreateIndex("dbo.Employees", "SalesStatus_SalesStatusID");
            CreateIndex("dbo.Currents", "SalesStatus_SalesStatusID");
            CreateIndex("dbo.Products", "SalesStatus_SalesStatusID");
        }
    }
}
