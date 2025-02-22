﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Display(Name = "Fatura Seri No")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        [Display(Name = "Fatura Sıra No")]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        [Display(Name = "Vergi Dairesi")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Eden")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Alan")]
        public string TeslimAlan { get; set; }
        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}