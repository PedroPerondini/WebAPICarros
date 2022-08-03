using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPICarros.Core.Services.Interfaces;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ITokenServices _tokenServices;

        public UserController(IUserServices userServices,
                              ITokenServices tokenServices)
        {
            _userServices = userServices;
            _tokenServices = tokenServices;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            try
            {
                var user = await _userServices.GetUserAsync(model.Username, model.Password);

                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }

                var token = await _tokenServices.GenerateToken(user);

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
        [Route("insert")]
        [Authorize(Roles = "Desenvolvedor")]
        public async Task<ActionResult<User>> InsertUserAsync(User user)
        {
            try
            {
                await _userServices.InsertUserAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
