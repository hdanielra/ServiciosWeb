using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb.Dominio
{
    public class Libro
    {
        public int idLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Idioma { get; set; }
        public short? Disponible { get; set; }
    }
}
