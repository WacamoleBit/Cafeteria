using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cafe.Web.Models
{
    public class BebidaViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        public int Precio { get; set; }
    }
}