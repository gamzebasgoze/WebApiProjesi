using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcguzellik.Models
{
    public class mvcHizmetlerModel
    {
        public int HizmetNo { get; set; }
        [Required(ErrorMessage = "Ad Soyad girilmesi zorunludur.")] //Ad soyad girilmesi zorunlu
        public string HizmetAdi { get; set; }
        public string HizmetAmaci { get; set; }
        public int Fiyat { get; set; }
    }
}