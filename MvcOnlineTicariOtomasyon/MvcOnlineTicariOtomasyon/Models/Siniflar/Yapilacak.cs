using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }
        public bool Durum { get; set; }
    }
}