using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CarroController : Controller
    {
        private readonly CarrosServices _carrosServices;
        public CarroController(CarrosServices carrosServices)
        {
            _carrosServices = carrosServices;
        }

        [HttpPost]
        public ActionResult<CarroModel> CreateCarro ([FromBody] CarroModel carro, [FromHeader] string requestToken)
        {
            if (Token.TokenKey != requestToken) 
            {
                return Unauthorized("Você não está autorizado à realizar essa operação!");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Os parâmetros informados são inválidos");
                }

                _carrosServices.CreateCarro(carro);

                return carro;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("GetId/{id}")]
        public ActionResult<CarroModel> GetById (int id, [FromHeader] string requestToken)
        {
            if (Token.TokenKey != requestToken)
            {
                return Unauthorized("Você não está autorizado à realizar essa operação!");
            }

            try
            {
                var carroResponse = _carrosServices.GetCarroById(id);

                if (String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }

                return carroResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteId/{id}")]
        public IActionResult DeleteCarroById(int id, [FromHeader] string requestToken)
        {
            if (Token.TokenKey != requestToken)
            {
                return Unauthorized("Você não está autorizado à realizar essa operação!");
            }

            try
            {

                if (String.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }

                _carrosServices.RemoveCarroById(id);

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
