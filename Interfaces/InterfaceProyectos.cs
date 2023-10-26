using Microsoft.EntityFrameworkCore;
using TechOilActive.Models;

namespace TechOilActive.Interfaces
{
    public interface InterfaceProyectos
    {
        IEnumerable<Proyecto> GetAllProyectos();
        Proyecto GetProyectoById(int id);
        void AddProyecto(Proyecto proyecto);
        void UpdateProyecto(Proyecto proyecto);
        void DeleteProyecto(int id);
    }
}
