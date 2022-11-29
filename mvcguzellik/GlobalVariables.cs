using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace mvcguzellik
{
    public class GlobalVariables
    {
        public static HttpClient WebApClient = new HttpClient();
        static GlobalVariables()
        {
            WebApClient.BaseAddress = new Uri("https://localhost:44344/"); //api bağlanma adresi-katmanli api sağ tık-proporties-web 
            WebApClient.DefaultRequestHeaders.Clear(); //önceden kalan url leri sil
            WebApClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}