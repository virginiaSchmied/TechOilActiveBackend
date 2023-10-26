using System.ComponentModel.DataAnnotations;

namespace TechOilActive.Models
{
    public class Servicio
    {
        [Key]
        public int codServicio { get; set; }

        public string? descr { get; set; }

        public int? estado { get; set; }

        public int? valorHora { get; set; }
    }
}
