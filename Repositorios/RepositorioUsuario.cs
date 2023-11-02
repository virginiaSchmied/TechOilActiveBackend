using TechOilActive.Interfaces;
using TechOilActive.Models;

namespace TechOilActive.Repositorios
{
    public class RepositorioUsuario : InterfaceUsuarios
    {
        public readonly MyDbContext _dbContext;
        public RepositorioUsuario(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _dbContext.Usuario.ToList();
        }

        public Usuario GetUsuarioById(int id)
        {

            Usuario usuario = _dbContext.Usuario.FirstOrDefault(p => p.codUsuario == id);

            return usuario;
        }

        public void AddUsuario(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _dbContext.Usuario.Update(usuario);
            _dbContext.SaveChanges();
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _dbContext.Usuario.FirstOrDefault(p => p.codUsuario == id);
            if (usuario != null)
            {
                _dbContext.Usuario.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
    }
}