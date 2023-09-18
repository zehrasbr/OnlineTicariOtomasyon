using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class SalesStatus
    {
        [Key]
        public int SalesStatusID { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}