using TechOilActive.Interfaces;
using TechOilActive.Models;

namespace TechOilActive.Repositorios
{
    public class RepositorioTrabajo : InterfaceTrabajos
    {
        public readonly MyDbContext _dbContext;
        public RepositorioTrabajo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Trabajo> GetAllTrabajos()
        {
            return _dbContext.Trabajo.ToList();
        }

        public Trabajo GetTrabajoById(int id)
        {
            return _dbContext.Trabajo.FirstOrDefault(p => p.codTrabajo == id);
        }

        public void AddTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajo.Add(trabajo);
            _dbContext.SaveChanges();
        }

        public void UpdateTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajo.Update(trabajo);
            _dbContext.SaveChanges();
        }

        public void DeleteTrabajo(int id)
        {
            var trabajo = _dbContext.Trabajo.FirstOrDefault(p => p.codTrabajo == id);
            if (trabajo != null)
            {
                _dbContext.Trabajo.Remove(trabajo);
                _dbContext.SaveChanges();
            }
        }
    }
}