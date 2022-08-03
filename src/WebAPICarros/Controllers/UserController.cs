using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPICarros.Core.Services.Interfaces;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("InsertUser")]
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
