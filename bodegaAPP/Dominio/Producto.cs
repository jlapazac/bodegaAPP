using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bodegaAPP.Dominio
{
    public class Producto
    {
        public int id { get; set; }
        public string idproducto { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public double precio { get; set; }
        public bool activo { get; set; }
        public string idcategoria { get; set; }
        public string descategoria { get; set; }
    }
}