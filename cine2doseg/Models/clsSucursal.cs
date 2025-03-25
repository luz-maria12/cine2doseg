using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace cine2doseg.Models
{
    public class clsSucursal
    {
        public string clave { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string url { get; set; }
        public string logo { get; set; }

        // Constructor sin parámetros
        public clsSucursal() { }

        // Constructor con parámetros
        public clsSucursal(string clave, string nombre, string direccion, string url, string logo)
        {
            this.clave = clave;
            this.nombre = nombre;
            this.direccion = direccion;
            this.url = url;
            this.logo = logo;
        }
    }
}
