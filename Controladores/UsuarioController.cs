using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TechOilActive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer;
using TechOilActive.Interfaces;
using TechOilActive.Repositorios;

namespace TechOilActive.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly InterfaceUsuarios RepositorioUsuario;

        public UsuarioController(InterfaceUsuarios usuariosRepository)
        {
            RepositorioUsuario = usuariosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuario = RepositorioUsuario.GetAllUsuarios();
            if (usuario.Count() == 0)
            {
                return NotFound("No se encontraron usuarios");
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = RepositorioUsuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound("No hay usuarios");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            RepositorioUsuario.AddUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.codUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario updatedUsuario)
        {
            var usuario = RepositorioUsuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound("No hay usuarios");
            }
            usuario.nombre = updatedUsuario.nombre;
            usuario.dni = updatedUsuario.dni;
            usuario.tipo = updatedUsuario.tipo;
            usuario.contraseña = updatedUsuario.contraseña;

            RepositorioUsuario.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = RepositorioUsuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound("No se encontraron usuarios que eliminar");
            }
            RepositorioUsuario.DeleteUsuario(id);
            return Ok("Borrado exitosamente");
        }
    }
}
