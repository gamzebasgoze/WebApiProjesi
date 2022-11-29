using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcguzellik.Models
{
    public class mvcUrunlerModel
    {
        public int UrunNo { get; set; }
        [Required(ErrorMessage = "Ad Soyad girilmesi zorunludur.")] //Ad soyad girilmesi zorunlu
        public string UrunAdi { get; set; }
        public string UrunFiyat { get; set; }
        public int KullanimAmaci { get; set; }
    }
}