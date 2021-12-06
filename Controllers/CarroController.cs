using System;
using Microsoft.AspNetCore.Mvc;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [Route("Id")]
        public ActionResult<CarroModel> GetById([FromBody] CarroModel carro)
        {

            int idCarro = carro.Id;
            var carroResponse = _carrosServices.GetCarroById(idCarro);

            if (String.IsNullOrEmpty(idCarro.ToString()))
                return NotFound();

            return carroResponse;
        }

        [HttpPost]
        public ActionResult<CarroModel> CreateCarro ([FromBody] CarroModel carro)
        {
            _carrosServices.CreateCarro(carro);
            return carro;
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteCarroById([FromBody] CarroModel carro)
        {
            int idCarro = carro.Id;

            if (String.IsNullOrEmpty(idCarro.ToString()))
                return NotFound();

            _carrosServices.RemoveCarroById(idCarro);

            return Ok("O carro foi deletado com sucesso!");
        }
    }
}
