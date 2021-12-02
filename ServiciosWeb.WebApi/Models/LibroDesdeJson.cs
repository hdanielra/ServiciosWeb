using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWeb.WebApi.Models
{
    public class LibroDesdeJson
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int idLibro { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string Idioma { get; set; }
            public int Disponible { get; set; }
        }

    }
}