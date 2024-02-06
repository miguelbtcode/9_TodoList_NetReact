using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoIst.Api.Models;

namespace TodoIst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        private readonly ReactjsCsharpContext _dbContext;

        public TareaController(ILogger<TareaController> logger, ReactjsCsharpContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista() {
            
            List<Tarea> lista = await _dbContext.Tareas.OrderByDescending(t => t.IdTarea).ThenBy(t => t.FechaRegistro).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}