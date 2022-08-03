using System.Threading.Tasks;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<User> GetUserAsync(string username, string password);
        Task<User> InsertUserAsync(User user);
    }
}
