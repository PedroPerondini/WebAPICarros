using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;
using WebAPICarros.Repository.Interfaces;

namespace WebAPICarros.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userRepository;

        public UserRepository (IUserDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _userRepository = database.GetCollection<User>(dbSettings.CollectionName);
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            //var filter = Builders<User>.Filter.Eq(x => x.Username, username) &
            //             Builders<User>.Filter.Eq(x => x.Password, password);

            try
            {
                return await _userRepository.Find(user => user.Username == username &&
                                                          user.Password == password).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<User> InsertUserAsync(User user)
        {
            try
            {
                await _userRepository.InsertOneAsync(user);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
