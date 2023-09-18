using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Bill
    {
        public int BillID { get; set; }
        public string BillSerialNo { get; set; }
        public string BillSequenceNo { get; set; }
        public DateTime Date { get; set; }
        public string TaxAdministration { get; set; }
        public DateTime Clock { get; set; }
        public string Deliverer { get; set; }
        public string DeliveryArea { get; set; }
    }
}