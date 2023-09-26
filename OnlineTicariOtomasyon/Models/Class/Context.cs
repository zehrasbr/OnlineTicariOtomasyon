using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesStatus> SalesStatuses { get; set; }
    }
}