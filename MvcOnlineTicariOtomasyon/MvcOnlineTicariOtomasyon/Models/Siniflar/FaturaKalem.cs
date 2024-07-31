using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        [Display(Name = "Birim Fiyatı")]
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        [Display(Name = "Fatura Id")]
        public int FaturaId {  get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}