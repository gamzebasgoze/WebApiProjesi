using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcguzellik.Models
{
    public class mvcCalisanlarModel
    {
        public int CalisanNo { get; set; }
        [Required(ErrorMessage = "Ad Soyad girilmesi zorunludur.")] //Ad soyad girilmesi zorunlu
        public string CalisanAdi { get; set; }
        public string Yas { get; set; }
        public int Telefon { get; set; }
        public int Mail { get; set; }
        public int Adres { get; set; }
    }
}