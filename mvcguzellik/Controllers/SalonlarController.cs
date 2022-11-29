using mvcguzellik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace mvcguzellik.Controllers
{
    public class SalonlarController : Controller
    {
        // GET: Salonlar
        public ActionResult Index()
        {
            IEnumerable<mvcSalonlarModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Salonlars").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<mvcSalonlarModel>>().Result;
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
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Salonlars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcSalonlarModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Ekle(mvcSalonlarModel salonlar)
        {
            if (salonlar.SalonNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Salonlars", salonlar).Result;
                TempData["SuccessMessage"] = "Ekleme işlemi başarıyla gerçekleştirildi.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Salonlars/" + salonlar.SalonNo, salonlar).Result;
                TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla gerçekleştirildi.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Salonlars/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme işlemi başarıyla gerçekleştirildi.";
            return RedirectToAction("Index");
        }
    }
}