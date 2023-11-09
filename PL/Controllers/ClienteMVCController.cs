using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClienteMVCController : Controller
    {
            [HttpGet]
            public IActionResult GetAll()
            {
                ML.Emisor emisor = new ML.Emisor();
                emisor.Emisoras = new List<Object>();

                //LLamando al servicio
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7098/api/");
                    var responseTask = client.GetAsync("emisor/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultEmisor in readTask.Result.Objects)
                        {
                            ML.Emisor resultItems = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Emisor>(resultEmisor.ToString());
                            emisor.Emisoras.Add(resultItems);
                        }
                    }


                }

                return View(emisor);



            }

        [HttpGet]
        public IActionResult Form(string IdEmisor)
        {
            ML.Emisor emisor = new ML.Emisor();

            if (IdEmisor != null)

            {

                emisor.Accion = "Update";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7098/api/");
                    var resposeTask = client.GetAsync("emisor/GetById/" + IdEmisor);
                    resposeTask.Wait();

                    var resultServicio = resposeTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Emisor resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Emisor>(readTask.Result.Object.ToString());
                        emisor = resultItem;

                    }
                }


            }
            else
            {
                emisor.Accion = "Add";
            }

            return View(emisor);
        }


        [HttpPost]
        public IActionResult Form(ML.Emisor emisor)
        {
            if (emisor.Accion == "Add")
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7098/api/");
                    var postTask = client.PostAsJsonAsync<ML.Emisor>("emisor/Add", emisor);
                    postTask.Wait();

                    var resultServicio = postTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Agregado!!!";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error!!!";
                    }

                }


            }
            else
            {


            }

            return PartialView("Modal");

        }

    }
}

