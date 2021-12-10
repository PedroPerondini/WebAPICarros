using Microsoft.AspNetCore.Mvc;
using System;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : Controller
    {
        private readonly CarrosServices _carrosServices;
        private readonly Token _token;

        public CarroController(CarrosServices carrosServices, Token token)
        {
            _carrosServices = carrosServices;
            _token = token;
        }

        [HttpPost]
        public ActionResult<CarroModel> CreateCarro ([FromBody] CarroModel carro, [FromHeader] string requestToken)
        {
            if (_token.ToString() != requestToken)
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
        [Route("GetId")]
        public ActionResult<CarroModel> GetById([FromBody] CarroModel carro, [FromHeader] string requestToken)
        {

            if (_token.ToString() != requestToken)
            {
                return Unauthorized("Você não está autorizado à realizar essa operação!");
            }

            try
            {
                int idCarro = carro.Id;
                var carroResponse = _carrosServices.GetCarroById(idCarro);

                if (String.IsNullOrEmpty(idCarro.ToString()))
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
        [Route("DeleteId")]
        public IActionResult DeleteCarroById([FromBody] CarroModel carro, [FromHeader] string requestToken)
        {
            if (_token.ToString() != requestToken)
            {
                return Unauthorized("Você não está autorizado à realizar essa operação!");
            }

            try
            {
                int idCarro = carro.Id;

                if (String.IsNullOrEmpty(idCarro.ToString()))
                {
                    throw new Exception("Não foi informado um ID válido na requisição");
                }

                _carrosServices.RemoveCarroById(idCarro);

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
