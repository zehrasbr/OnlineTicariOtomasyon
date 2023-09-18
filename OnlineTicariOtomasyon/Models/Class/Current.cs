using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }
        public string CurrentName { get; set; }
        public string CurrentSurname { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentMail { get; set; }
    }
}