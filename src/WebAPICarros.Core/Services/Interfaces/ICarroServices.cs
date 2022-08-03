using System.Threading.Tasks;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Core.Services
{
    public interface ICarroServices
    {
        Task<CarroModel> GetCarroByIdAsync(int id);
        Task<CarroModel> CreateCarro(CarroModel carroModel);
        Task UpdateCarroById(int id, CarroModel carroModel);
        Task RemoveCarroById(int id);

    }
}
