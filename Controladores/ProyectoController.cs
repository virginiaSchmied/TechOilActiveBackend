using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TechOilActive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer;
using TechOilActive.Interfaces;

namespace TechOilActive.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly InterfaceProyectos RepositorioProyecto;

        public ProyectoController(InterfaceProyectos proyectosRepository)
        {
            RepositorioProyecto = proyectosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var proyecto = RepositorioProyecto.GetAllProyectos();
            if (proyecto.Count() == 0)
            {
                return NotFound("No se encontraron proyectos");
            }
            else
            {
                return Ok(proyecto);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var proyecto = RepositorioProyecto.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound("No existe este proyecto");
            }
            return Ok(proyecto);
        }

        [HttpPost]
        public IActionResult Post(Proyecto proyecto)
        {
            RepositorioProyecto.AddProyecto(proyecto);
            return CreatedAtAction(nameof(Get), new { id = proyecto.codProyecto }, proyecto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Proyecto updatedProyecto)
        {
            var proyecto = RepositorioProyecto.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound("No existe este proyecto");
            }
            proyecto.nombre = updatedProyecto.nombre;
            proyecto.direccion = updatedProyecto.direccion;
            proyecto.estado = updatedProyecto.estado;
            RepositorioProyecto.UpdateProyecto(proyecto);
            return Ok("Modificado exitosamente");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var proyecto = RepositorioProyecto.GetProyectoById(id);
            if (proyecto == null)
            {
                return NotFound("No se encontraron proyectos que eliminar");
            }
            RepositorioProyecto.DeleteProyecto(id);
            return Ok("Borrado exitosamente");
        }
    }
}

