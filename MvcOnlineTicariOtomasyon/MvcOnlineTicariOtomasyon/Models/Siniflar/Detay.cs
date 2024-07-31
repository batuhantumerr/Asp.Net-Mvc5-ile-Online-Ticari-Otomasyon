using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }
        [Display(Name = "Ürün Adı")]
        public string UrunAd { get; set; }
        [Display(Name = "Ürün Bilgi")]
        public string UrunBilgi { get; set; }
    }
}