//using ServiciosWeb.ClienteConsola.ServiceLibroASMX;
//using ServiciosWeb.ClienteConsola.ServiceLibroWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Net.Http;
using ServiciosWeb.Datos.Modelo;

namespace ServiciosWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //invocar servicio ASMX --------------------------------------------
            //ServicioLibroSoapClient clienteAsmx = new ServicioLibroSoapClient();
            //var libros1 = clienteAsmx.ObtenerLibros();
            //------------------------------------------------------------------


            //invocar servicio WCF ---------------------------------------------
            //ServicioLibroClient clienteWcf = new ServicioLibroClient();
            //var libros2 = clienteWcf.ObtenerLibros(1);
            //------------------------------------------------------------------


            //------------------------------------------------------------------
            //invocar servicio REST (WebApi)  ... agregar using System.Net.Http;
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44380/");

            var request = clienteHttp.GetAsync("api/Libro").Result;
            //clienteHttp.PostAsync();
            //clienteHttp.PutAsync();
            //clienteHttp.DeleteAsync();

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;

                //se usa una libreria llamada NewtonJson, la cual hay que agregar por Paquetes Nuget
                //esa librería nos permite convertir un json por ej en una clase/objeto
                //ojo, que hay un error acá.. porque tuve que agregar la referencia a la capa de datos
                //para poder usar Libro... sin embargo desde la Vista, no se debería acceder directamente
                //a la capa de datos... hay que averiguar cómo se soluciona esto para web api
                // se solucionó creando una librería Dominio, que solo tiene el objeto libro sin métodos
                var listado = JsonConvert.DeserializeObject<List<Libro>>(resultString);

                foreach (var item in listado)
                {
                    Console.WriteLine(item.Titulo);
                }

                Console.ReadLine();
            }
            //------------------------------------------------------------------
        }
    }
}
