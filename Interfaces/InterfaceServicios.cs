using Microsoft.EntityFrameworkCore;
using TechOilActive.Models;

namespace TechOilActive.Interfaces
{
    public interface InterfaceServicios
    {
        IEnumerable<Servicio> GetAllServicios();
        Servicio GetServicioById(int id);
        void AddServicio(Servicio servicio);
        void UpdateServicio(Servicio servicio);
        void DeleteServicio(int id);
    }
}