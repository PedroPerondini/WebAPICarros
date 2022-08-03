using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;
using WebAPICarros.Repository.Interfaces;

namespace WebAPICarros.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly IMongoCollection<CarroModel> _carroRepository;

        public CarroRepository(ICarroDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _carroRepository = database.GetCollection<CarroModel>(dbSettings.CollectionName);
        }


        public async Task<CarroModel> GetCarroById(int id)
        {
            try
            {
                return await _carroRepository.Find(c => c.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CarroModel> CreateCarro(CarroModel carroModel)
        {
            try
            {
                await _carroRepository.InsertOneAsync(carroModel);
                return carroModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateCarroById(int id, CarroModel carroModel)
        {
            try
            {
                await _carroRepository.ReplaceOneAsync(carroModel => carroModel.Id == id, carroModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveCarroById(int id)
        {
            try
            {
                await _carroRepository.DeleteOneAsync(carroModel => carroModel.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}