using Api_SistemaRegistroGastos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Api_SistemaRegistroGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public GastosController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gastos>>> Get()
        {
            return await _Context.Gastos.OrderByDescending(g=>g.Fecha).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Gastos>>> Post(Gastos gastos)
        {
            _Context.Gastos.Add(gastos);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gastos.Id },gastos );
        }
    }
}
