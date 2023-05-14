using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.API
{
    public class BebidaResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }
}