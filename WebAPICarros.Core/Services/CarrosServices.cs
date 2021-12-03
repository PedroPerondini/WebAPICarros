using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Core.Services
{
    public class CarrosServices
    {
        private readonly IMongoCollection<CarroModel> _carro;

        public CarrosServices (IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<CarroModel>(settings.CarroCollectionName);
        }

        public List<CarroModel> Get()
        {
            try
            {
                return _carro.Find(c => true).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CarroModel Get(int id)
        {
            try
            {
                return _carro.Find<CarroModel>(carroModel => carroModel.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        } 

        public CarroModel Create (CarroModel carroModel)
        {
            try
            {
                _carro.InsertOne(carroModel);
                return carroModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(int id, CarroModel carroModel)
        {
            try
            {
                _carro.ReplaceOne(carroModel => carroModel.Id == id, carroModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Remove(CarroModel carroModel)
        {
            try
            {
                _carro.DeleteOne(carroModel => carroModel.Id == carroModel.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _carro.DeleteOne(carroModel => carroModel.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
