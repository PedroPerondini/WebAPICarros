using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebAPICarros.Core.Services.Interfaces;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CarroController : Controller
    {
        private readonly ICarroServices _carrosServices;
        private readonly IUserServices _userServices;
        private readonly ITokenServices _tokenServices;

        public CarroController(ICarroServices carrosServices,
                               IUserServices userServices,
                               ITokenServices tokenServices)
        {
            _carrosServices = carrosServices;
            _userServices = userServices;
            _tokenServices = tokenServices;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] string username, [FromBody] string password)
        {
            try
            {
                var user = await _userServices.GetUserAsync(username, password);

                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }

                var token = _tokenServices.GenerateToken(user);

                user.Password = "";

                return new { user, token };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("InsertCar")]
        [Authorize(Roles = "Desenvolvedor")]
        public async Task<ActionResult<CarroModel>> CreateCarro([FromBody] CarroModel carro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Os parâmetros informados são inválidos");
                }

                await _carrosServices.CreateCarro(carro);

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

                return carroResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch]
        [Route("UpdateId/{id}")]
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
        [Route("DeleteId/{id}")]
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
