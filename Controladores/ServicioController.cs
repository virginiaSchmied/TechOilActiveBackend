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
    public class ServicioController : ControllerBase
    {
        private readonly InterfaceServicios RepositorioServicio;

        public ServicioController(InterfaceServicios serviciosRepository)
        {
            RepositorioServicio = serviciosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var servicio = RepositorioServicio.GetAllServicios();
            if (servicio.Count() == 0)
            {
                return NotFound("No se encontraron servicios");
            }
            else
            {
                return Ok(servicio);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var servicio = RepositorioServicio.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound("No hay servicios");
            }
            return Ok(servicio);
        }

        [HttpPost]
        public IActionResult Post(Servicio servicio)
        {
            RepositorioServicio.AddServicio(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.codServicio }, servicio);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Servicio updatedServicio)
        {
            var servicio = RepositorioServicio.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound("No hay servicios");
            }
            servicio.descr = updatedServicio.descr;
            servicio.estado = updatedServicio.estado;
            servicio.valorHora = updatedServicio.valorHora;
           
            RepositorioServicio.UpdateServicio(servicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servicio = RepositorioServicio.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound("No se encontraron servicios que eliminar");
            }
            RepositorioServicio.DeleteServicio(id);
            return Ok("Borrado exitosamente");
        }
    }
}

