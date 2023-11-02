using Microsoft.EntityFrameworkCore;
using TechOilActive.Models;

namespace TechOilActive.Interfaces
{
    public interface InterfaceUsuarios
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
    }
}