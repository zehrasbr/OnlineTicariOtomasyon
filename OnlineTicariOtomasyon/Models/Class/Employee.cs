using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Display(Name = "Personel Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public ICollection<SalesStatus> SalesStatuses { get; set; }
        public int Departmanid { get; set; }
        public virtual Department Department { get; set; }
        public bool Status { get; set; }
    }
}