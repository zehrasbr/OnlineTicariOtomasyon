using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Detay
    {
        [Key] 
        public int DetayID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string producinfo { get; set; }
    }
}