using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TechOilActive.Models
{
    public class Proyecto
    {
        [Key]
        public int codProyecto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        [BindProperty]
        public int estado { get; set; }


    }
}
