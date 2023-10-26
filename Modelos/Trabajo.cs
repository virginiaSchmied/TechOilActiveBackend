using System.ComponentModel.DataAnnotations;

namespace TechOilActive.Models
{
    public class Trabajo
    {
        [Key]
        public int codTrabajo { get; set; }

        public int fecha { get; set; }

        public int codProyecto { get; set; }

        public int codServicio { get; set; }

        public int? cantHoras { get; set; }

        public int? valorHora { get; set; }

        public int? costo { get; set; }

    }
}
