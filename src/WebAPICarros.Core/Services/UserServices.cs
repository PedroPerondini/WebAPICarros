using System.Threading.Tasks;
using WebAPICarros.Core.Services.Interfaces;
using WebAPICarros.Domain.Model;
using WebAPICarros.Repository.Interfaces;

namespace WebAPICarros.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _userRepository.GetUserAsync(username, password);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            return await _userRepository.InsertUserAsync(user);
        }
    }
}
