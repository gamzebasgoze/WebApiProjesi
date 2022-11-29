using mvcguzellik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace mvcguzellik.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        public ActionResult Index()
        {
            IEnumerable<mvcUrunlerModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Urunler").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<mvcUrunlerModel>>().Result;
            return View(calList);
        }
        public ActionResult Ekle(int id = 0) //CROP işlemi hem ekleme hem güncelleme işlemi
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Urunlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcUrunlerModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Ekle(mvcUrunlerModel urunler)
        {
            if (urunler.UrunNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Urunlers", urunler).Result;
                TempData["SuccessMessage"] = "Ekleme işlemi başarıyla gerçekleştirildi.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Urunlers/" + urunler.UrunNo, urunler).Result;
                TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla gerçekleştirildi.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Urunlers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme işlemi başarıyla gerçekleştirildi.";
            return RedirectToAction("Index");
        }
    }
}