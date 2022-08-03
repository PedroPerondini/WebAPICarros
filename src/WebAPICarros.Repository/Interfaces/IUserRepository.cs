using System.Threading.Tasks;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username, string password);
        Task<User> InsertUserAsync(User user);
    }
}
