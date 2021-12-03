using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : Controller
    {
        private readonly CarrosServices _carrosServices;

        public CarroController(CarrosServices carrosServices)
        {
            _carrosServices = carrosServices;
        }

        [HttpGet]
        public ActionResult<List<CarroModel>> GetCarro()
        {
            return _carrosServices.GetCarro();
        }

        [HttpGet("{id:length(24)}", Name = "GetCarroById")]
        public ActionResult<CarroModel> GetCarroById (int id)
        {
            var carro = _carrosServices.GetCarroById(id);

            if (carro == null)
                return NotFound();

            return carro;
        }

        [HttpPost]
        public ActionResult<CarroModel> CreateCarro ([FromBody] CarroModel carro)
        {
            _carrosServices.CreateCarro(carro);
            return carro;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateCarroById(int id, CarroModel carroIn)
        {
            var carro = _carrosServices.GetCarroById(id);

            if (carro == null)
                return NotFound();

            _carrosServices.UpdateCarroById(id, carroIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteCarroById(int id)
        {
            var carro = _carrosServices.GetCarroById(id);

            if (carro == null)
                return NotFound();

            _carrosServices.RemoveCarroById(carro.Id);

            return NoContent();
        }
    }
}
