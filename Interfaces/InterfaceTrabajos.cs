using Microsoft.EntityFrameworkCore;
using TechOilActive.Models;

namespace TechOilActive.Interfaces
{
    public interface InterfaceTrabajos
    {
        IEnumerable<Trabajo> GetAllTrabajos();
        Trabajo GetTrabajoById(int id);
        void AddTrabajo(Trabajo trabajo);
        void UpdateTrabajo(Trabajo trabajo);
        void DeleteTrabajo(int id);
    }
}