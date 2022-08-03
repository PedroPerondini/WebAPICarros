using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Repository.Interfaces
{
    public interface ICarroRepository
    {
        Task<CarroModel> GetCarroById(int id);
        Task<CarroModel> CreateCarro(CarroModel carroModel);
        Task UpdateCarroById(int id, CarroModel carroModel);
        Task RemoveCarroById(int id);

    }
}
