using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ServiciosWeb.ClienteWeb.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            //------------------------------------------------------------------
            //invocar servicio REST (WebApi)  ... agregar using System.Net.Http;
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost/Apis/");
            //clienteHttp.BaseAddress = new Uri("https://localhost:44380/");

            var request = clienteHttp.GetAsync("api/Libro").Result;
            //clienteHttp.PostAsync();
            //clienteHttp.PutAsync();
            //clienteHttp.DeleteAsync();

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;

                //se usa una libreria llamada NewtonJson, la cual hay que agregar por Paquetes Nuget
                //esa librería nos permite convertir un json por ej en una clase/objeto
                var listado = JsonConvert.DeserializeObject<List<Libro>>(resultString);

                return View(listado);
            }
            //si no retorna una lista, envíe una lista vacía
            return View(new List<Libro>());
        }
    }
}