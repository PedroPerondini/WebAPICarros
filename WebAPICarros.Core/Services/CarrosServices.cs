using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

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


        public CarroModel GetCarroById (int id)
        {
            try
            {
                return _carro.Find(c => c.Id == id).FirstOrDefault();
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
