using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bodegaAPP.Dominio
{
    public class Bodega
    {
        public int id { get; set; }
        public string idbodega { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public bool activo { get; set; }
        public string iduser { get; set; }
    }
}