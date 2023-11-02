using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TechOilActive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer;
using TechOilActive.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TechOilActive.Repositorios;

namespace TechOilActive.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ControladorAutenticacion : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(new { Messaje = "Solicitud realizada con exito!", UserId = userId });
        }
    }
}
