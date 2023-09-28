namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Currents", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropForeignKey("dbo.Employees", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropForeignKey("dbo.Products", "SalesStatus_SalesStatusID", "dbo.SalesStatus");
            DropIndex("dbo.Products", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Currents", new[] { "SalesStatus_SalesStatusID" });
            DropIndex("dbo.Employees", new[] { "SalesStatus_SalesStatusID" });
            AddColumn("dbo.SalesStatus", "Current_CurrentID", c => c.Int());
            AddColumn("dbo.SalesStatus", "Employee_EmployeeID", c => c.Int());
            AddColumn("dbo.SalesStatus", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.SalesStatus", "Current_CurrentID");
            CreateIndex("dbo.SalesStatus", "Employee_EmployeeID");
            CreateIndex("dbo.SalesStatus", "Product_ProductID");
            AddForeignKey("dbo.SalesStatus", "Current_CurrentID", "dbo.Currents", "CurrentID");
            AddForeignKey("dbo.SalesStatus", "Employee_EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.SalesStatus", "Product_ProductID", "dbo.Products", "ProductID");
            DropColumn("dbo.Products", "SalesStatus_SalesStatusID");
            DropColumn("dbo.Currents", "SalesStatus_SalesStatusID");
            DropColumn("dbo.Employees", "SalesStatus_SalesStatusID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "SalesStatus_SalesStatusID", c => c.Int());
            AddColumn("dbo.Currents", "SalesStatus_SalesStatusID", c => c.Int());
            AddColumn("dbo.Products", "SalesStatus_SalesStatusID", c => c.Int());
            DropForeignKey("dbo.SalesStatus", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.SalesStatus", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.SalesStatus", "Current_CurrentID", "dbo.Currents");
            DropIndex("dbo.SalesStatus", new[] { "Product_ProductID" });
            DropIndex("dbo.SalesStatus", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.SalesStatus", new[] { "Current_CurrentID" });
            DropColumn("dbo.SalesStatus", "Product_ProductID");
            DropColumn("dbo.SalesStatus", "Employee_EmployeeID");
            DropColumn("dbo.SalesStatus", "Current_CurrentID");
            CreateIndex("dbo.Employees", "SalesStatus_SalesStatusID");
            CreateIndex("dbo.Currents", "SalesStatus_SalesStatusID");
            CreateIndex("dbo.Products", "SalesStatus_SalesStatusID");
            AddForeignKey("dbo.Products", "SalesStatus_SalesStatusID", "dbo.SalesStatus", "SalesStatusID");
            AddForeignKey("dbo.Employees", "SalesStatus_SalesStatusID", "dbo.SalesStatus", "SalesStatusID");
            AddForeignKey("dbo.Currents", "SalesStatus_SalesStatusID", "dbo.SalesStatus", "SalesStatusID");
        }
    }
}
