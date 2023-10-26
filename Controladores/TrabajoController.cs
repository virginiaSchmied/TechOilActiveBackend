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
    public class TrabajoController : ControllerBase
    {
        private readonly InterfaceTrabajos RepositorioTrabajo;

        public TrabajoController(InterfaceTrabajos trabajosRepository)
        {
            RepositorioTrabajo = trabajosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trabajo = RepositorioTrabajo.GetAllTrabajos();
            if (trabajo.Count() == 0)
            {
                return NotFound("No se encontraron trabajos");
            }
            else
            {
                return Ok(trabajo);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trabajo = RepositorioTrabajo.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound("No hay trabajos");
            }
            return Ok(trabajo);
        }

        [HttpPost]
        public IActionResult Post(Trabajo trabajo)
        {
            RepositorioTrabajo.AddTrabajo(trabajo);
            return CreatedAtAction(nameof(Get), new { id = trabajo.codTrabajo }, trabajo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Trabajo updatedTrabajo)
        {
            var trabajo = RepositorioTrabajo.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound("No hay trabajos");
            }
            trabajo.fecha = updatedTrabajo.fecha;
            trabajo.codProyecto = updatedTrabajo.codProyecto;
            trabajo.codServicio = updatedTrabajo.codServicio;
            trabajo.cantHoras = updatedTrabajo.cantHoras;
            trabajo.valorHora = updatedTrabajo.valorHora;
            trabajo.costo = updatedTrabajo.costo;
            RepositorioTrabajo.UpdateTrabajo(trabajo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trabajo = RepositorioTrabajo.GetTrabajoById(id);
            if (trabajo == null)
            {
                return NotFound("No se encontraron trabajos que eliminar");
            }
            RepositorioTrabajo.DeleteTrabajo(id);
            return Ok("Borrado exitosamente");
        }
    }
}

