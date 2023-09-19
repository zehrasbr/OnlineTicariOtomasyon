using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSequenceNo { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        public DateTime Clock { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryArea { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}