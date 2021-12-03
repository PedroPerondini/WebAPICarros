using System;
using System.Collections.Generic;
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

        public List<CarroModel> GetCarro()
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

        public CarroModel GetCarroById(int id)
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

        public CarroModel CreateCarro (CarroModel carroModel)
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

        public void UpdateCarroById(int id, CarroModel carroModel)
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

        public void RemoveCarro(CarroModel carroModel)
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

        public void RemoveCarroById(int id)
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
