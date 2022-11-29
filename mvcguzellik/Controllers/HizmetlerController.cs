using mvcguzellik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace mvcguzellik.Controllers
{
    public class HizmetlerController : Controller
    {
        // GET: Hizmetler
        public ActionResult Index()
        {
            IEnumerable<mvcHizmetlerModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Hizmetlers").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<mvcHizmetlerModel>>().Result;
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
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Hizmetlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcHizmetlerModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Ekle(mvcHizmetlerModel hizmetler)
        {
            if (hizmetler.HizmetNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Hizmetlers", hizmetler).Result;
                TempData["SuccessMessage"] = "Ekleme işlemi başarıyla gerçekleştirildi.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Hizmetlers/" + hizmetler.HizmetNo, hizmetler).Result;
                TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla gerçekleştirildi.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Hizmetlers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme işlemi başarıyla gerçekleştirildi.";
            return RedirectToAction("Index");
        }
    }
}