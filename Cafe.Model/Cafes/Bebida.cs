using System;

namespace Cafe.Model.Cafes
{
    public class Bebida
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }
}
