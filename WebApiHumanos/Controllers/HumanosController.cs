using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApiHumanos.Entidades;

namespace WebApiHumanos.Controllers
{
   
    [ApiController]
    [Route("api/Humanos")]
    public class HumanosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public HumanosController (ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Humanos>>> Get()
        {
            return await context.Humanos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Humanos>> GetHuman(int Id)
        {
            var humano = await context.Humanos.FindAsync(Id);

            if (humano == null)
            {
                return NotFound("No existe el registro");
            }

            return humano;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Humanos Humano)
        {
            context.Add(Humano);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(Humanos Humano, int Id)
        {
            if(Humano.Id != Id)
            {
                return BadRequest("Error al actualizar");
            }

            context.Update(Humano);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Humanos.AnyAsync(x => x.Id == Id);
            if (!existe)
            {
                return NotFound("No existe el registro a eliminar");
            }

            context.Remove(new Humanos() { Id=Id });
            await context.SaveChangesAsync();
            return Ok();

        }
    }
    
}
