using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int CategoryName { get; set; }
        public ICollection<Product> Products  { get; set; }
    }
}