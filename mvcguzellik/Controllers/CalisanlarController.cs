using mvcguzellik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace mvcguzellik.Controllers
{
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        public ActionResult Index()
        {
            IEnumerable<mvcCalisanlarModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Calisanlars").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<mvcCalisanlarModel>>().Result;
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
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Calisanlars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCalisanlarModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Ekle(mvcCalisanlarModel calisanlar)
        {
            if (calisanlar.CalisanNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Calisanlars", calisanlar).Result;
                TempData["SuccessMessage"] = "Ekleme işlemi başarıyla gerçekleştirildi.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Calisanlars/" + calisanlar.CalisanNo, calisanlar).Result;
                TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla gerçekleştirildi.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Calisanlars/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme işlemi başarıyla gerçekleştirildi.";
            return RedirectToAction("Index");
        }
    }
}