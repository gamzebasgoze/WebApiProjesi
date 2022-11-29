using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcguzellik.Models
{
    public class mvcSalonlarModel
    {
        public int SalonNo { get; set; }
        [Required(ErrorMessage = "Ad Soyad girilmesi zorunludur.")] //Ad soyad girilmesi zorunlu
        public string SalonAdi { get; set; }
        public string CalisanSayisi { get; set; }
        public int VerilenHizmetler { get; set; }
        public int HizmetSayisi { get; set; }
    }
}