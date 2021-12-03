using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly CarroDbContext _context;

        public CarroController(CarroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroModel>>> GetCarro()
        {
            return await _context.CarroModels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarroModel>> GetCarroById(int id)
        {
            var carroModel = await _context.CarroModels.FindAsync(id);

            if (carroModel == null)
            {
                return NotFound();
            }

            return carroModel;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaCarro(int id, CarroModel carroModel)
        {
            if (id != carroModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExistsById(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarroModel>> PostCarro([FromBody] CarroModel carroModel)
        {
            _context.CarroModels.Add(carroModel);

            if (CarroExistsById(carroModel.Id))
            {
                return BadRequest($"O ID:{carroModel.Id} informado já existe");
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarroById", new { id = carroModel.Id }, carroModel);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarroById(int id)
        {
            var carroModel = await _context.CarroModels.FindAsync(id);
            if (carroModel == null)
            {
                return NotFound();
            }

            _context.CarroModels.Remove(carroModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExistsById(int id)
        {
            return _context.CarroModels.Any(e => e.Id == id);
        }
    }
}
