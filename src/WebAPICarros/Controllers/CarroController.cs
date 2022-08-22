using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Validation;

namespace WebAPICarros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class CarroController : Controller
    {
        private readonly ICarroServices _carrosServices;
        private readonly CarValidation _carValidation;
        
        public CarroController(ICarroServices carrosServices,
                               CarValidation carValidation)
        {
            _carrosServices = carrosServices;
            _carValidation = carValidation;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize(Roles = "Desenvolvedor")]
        public async Task<ActionResult<CarroModel>> CreateCarro([FromBody] CarroModel carro)
        {
            try
            {
                var validationResult = _carValidation.ValidateAsync(carro);
                if (!validationResult.Result.IsValid)
                {
                    return BadRequest(validationResult.Result.Errors);
                }

                await _carrosServices.CreateCarro(carro);

                return Ok(carro);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        [Authorize]
        public async Task<ActionResult<CarroModel>> GetById(int id)
        {
            try
            {
                if (String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }

                var carroResponse = await _carrosServices.GetCarroByIdAsync(id);

                return Ok(carroResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch]
        [Route("updatebyid/{id}")]
        [Authorize(Roles = "Desenvolvedor")]
        public async Task<IActionResult> UpdateCarroById(int id, CarroModel carroModel)
        {
            try
            {
                if (String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }

                await _carrosServices.UpdateCarroById(id, carroModel);

                return Ok("O update do carro foi feito com sucesso");
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete]
        [Route("deletebyid/{id}")]
        [Authorize(Roles = "Desenvolvedor")]
        public async Task<IActionResult> DeleteCarroById(int id)
        {
            try
            {
                if (String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }
                
                await _carrosServices.RemoveCarroById(id);

                return Ok("O carro foi deletado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
