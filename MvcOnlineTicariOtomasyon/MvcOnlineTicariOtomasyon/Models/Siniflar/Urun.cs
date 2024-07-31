using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        [Display(Name = "Ürün Adı")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }
        public bool Durum {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Ürün Görseli")]
        public string UrunGorsel { get; set; }
        [Display(Name = "Kategori Id")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}