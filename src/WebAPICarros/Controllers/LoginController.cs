using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebAPICar.Core.Services;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IMongoCollection<User> _user;

        public LoginController(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate( [FromBody] User model )
        {
            var user = await _user.Find(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenGenerate.Token(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }


        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = _user.Find(x => x.Username != null).ToList();
            return users;
        }


        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> post(
           [FromBody] User Model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Model.Role = "employee";
                _user.InsertOne(Model);
                Model.Password = "";
                return Ok(Model);
            }

            catch
            {
                return BadRequest( new { message = "Não Foi Possível Criar O Usuário" });
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Put(
            int id,
            [FromBody] User model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
            
            {
                return NotFound(new { message = "Usuário não encontrada" });
            }

            try
            {
                 await _user.ReplaceOneAsync( b => b.Id == model.Id,model);

                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

    }
}
