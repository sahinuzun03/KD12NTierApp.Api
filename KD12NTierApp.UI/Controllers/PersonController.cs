using KD12NTierApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace KD12NTierApp.UI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public IActionResult KisileriGetir()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7126/");//Api'nin local adresi veriyorsun eğer bu api server adresini veriyorsun.
                var responseTask = client.GetAsync("api/Person"); //Bilgileri getirecek olan api tarafındaki metodu tetikledik.
                responseTask.Wait();
                var resultTask = responseTask.Result;    //Dönen sonucu burada yakaladım

                if (responseTask.IsCompletedSuccessfully) //Bu işlem doğru bir şekilde döndümü ya da çalıştımı
                {
                    var readTask = resultTask.Content.ReadAsStringAsync(); //Sen git o listeyi oku bana string olarak dön.//JSON
                    readTask.Wait();

                    var okunanVeri = JsonConvert.DeserializeObject<List<Person>>(readTask.Result);
                    return View(okunanVeri);
                }
                else
                {
                    ViewBag.BosListe = "Liste bulunamamıstir";
                    return View(new List<Person>());
                }
            }
        }

        public IActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KisiEkle(Person person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7126/");//Api'nin local adresi veriyorsun eğer bu api server adresini veriyorsun.
                var responseTask = client.PostAsJsonAsync<Person>("api/Person", person); //Bilgileri getirecek olan api tarafındaki metodu tetikledik.
                responseTask.Wait();
                var resultTask = responseTask.Result;

                if (responseTask.IsCompletedSuccessfully) //Bu işlem doğru bir şekilde döndümü ya da çalıştımı
                {

                    return RedirectToAction("KisileriGetir", "Person");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet]
        public IActionResult KisileriGetir2()
        {
            string json = new WebClient().DownloadString("https://localhost:7126/api/Person");
            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(json);

            return View(personList);
        }
    }
}
