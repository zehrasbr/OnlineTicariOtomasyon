using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}