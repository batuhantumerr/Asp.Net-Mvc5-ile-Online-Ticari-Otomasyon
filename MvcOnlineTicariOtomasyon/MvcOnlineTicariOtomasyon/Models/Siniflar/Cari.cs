using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        [Display(Name = "Cari Adı")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        [Display(Name = "Cari Soyadı")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        [Display(Name = "Cari Şehir")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Display(Name = "Cari Mail")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Display(Name = "Cari Şifre")]
        public string CariSifre { get; set; }
        public bool Durum {  get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}