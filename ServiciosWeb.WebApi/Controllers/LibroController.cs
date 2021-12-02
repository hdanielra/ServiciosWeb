using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebApi.Controllers
{
    public class LibroController : ApiController
    {
        LibreriaConnection BD = new LibreriaConnection();

        /// <summary>
        /// Permite consultar la información de todos los libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            //IEnumerable es un objeto genérico para las listas. O sea que puedo retornar list, diccionarios, etc 
            var listado = BD.Libro.ToList();
            return listado;
        }

        [HttpGet]
        public Libro Get(int id)
        {
            var libro = BD.Libro.FirstOrDefault(x => x.idLibro == id);
            return libro;
        }

        [HttpPost]
        public bool Post(Libro libro)
        {
            BD.Libro.Add(libro);
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Put(Libro libro)
        {
            var libroActualizar = BD.Libro.FirstOrDefault(x => x.idLibro == libro.idLibro);
            libroActualizar.Autor = libro.Autor;
            libroActualizar.Disponible = libro.Disponible;
            libroActualizar.Idioma = libro.Idioma;
            libroActualizar.Titulo = libro.Titulo;

            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var libroEliminar = BD.Libro.FirstOrDefault(x => x.idLibro == id);
            BD.Libro.Remove(libroEliminar);

            return BD.SaveChanges() > 0;
        }
    }
}
