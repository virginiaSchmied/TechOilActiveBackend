using TechOilActive.Interfaces;
using TechOilActive.Models;

namespace TechOilActive.Repositorios
{
    public class RepositorioProyecto : InterfaceProyectos
    {
        public readonly MyDbContext _dbContext;
        public RepositorioProyecto(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Proyecto> GetAllProyectos()
        {
            return _dbContext.Proyecto.ToList();
        }

        public Proyecto GetProyectoById(int id)
        {
            return new Proyecto();
        }

        public void AddProyecto(Proyecto proyecto)
        {
            _dbContext.Proyecto.Add(proyecto);
            _dbContext.SaveChanges();
        }

        public void UpdateProyecto(Proyecto proyecto)
        {
            _dbContext.Proyecto.Update(proyecto);
            _dbContext.SaveChanges();
        }

        public void DeleteProyecto(int id)
        {
            var proyecto = _dbContext.Proyecto.FirstOrDefault(p => p.codProyecto == id);
            if (proyecto != null)
            {
                _dbContext.Proyecto.Remove(proyecto);
                _dbContext.SaveChanges();
            }
        }
    }
}