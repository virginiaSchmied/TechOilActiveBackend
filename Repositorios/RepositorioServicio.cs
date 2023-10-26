using TechOilActive.Interfaces;
using TechOilActive.Models;

namespace TechOilActive.Repositorios
{
    public class RepositorioServicio : InterfaceServicios
    {
        public readonly MyDbContext _dbContext;
        public RepositorioServicio(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            return _dbContext.Servicio.ToList();
        }

        public Servicio GetServicioById(int id)
        {
            return new Servicio();
        }

        public void AddServicio(Servicio servicio)
        {
            _dbContext.Servicio.Add(servicio);
            _dbContext.SaveChanges();
        }

        public void UpdateServicio(Servicio servicio)
        {
            _dbContext.Servicio.Update(servicio);
            _dbContext.SaveChanges();
        }

        public void DeleteServicio(int id)
        {
            var servicio = _dbContext.Servicio.FirstOrDefault(p => p.codServicio == id);
            if (servicio != null)
            {
                _dbContext.Servicio.Remove(servicio);
                _dbContext.SaveChanges();
            }
        }
    }
}