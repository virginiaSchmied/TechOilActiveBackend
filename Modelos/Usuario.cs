using System.ComponentModel.DataAnnotations;

namespace TechOilActive.Models
{
    public class Usuario
    {
        [Key]
        public int codUsuario { get; set; }

        public string? nombre { get; set; }

        public int? dni { get; set; }

        public int? tipo { get; set; }

        public int? contraseña { get; set; }
    }
}
