using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebApiCarros.Repository.Interface;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebApiCarros.Repository
{
    public class MongoRepository<BaseRepository> : IMongoRepository<BaseRepository> where BaseRepository : IBaseRepository
    {
        private readonly IMongoCollection<CarroModel> _carro;

        public MongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<CarroModel>(settings.CarroCollectionName);
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<BaseRepository, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseRepository> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(ICollection<BaseRepository> documents)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(ICollection<BaseRepository> documents)
        {
            throw new NotImplementedException();
        }

        public void InsertOne(BaseRepository document)
        {
            throw new NotImplementedException();
        }

        public Task InsertOneAsync(BaseRepository document)
        {
            throw new NotImplementedException();
        }

        public void ReplaceOne(BaseRepository document)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceOneAsync(BaseRepository document)
        {
            throw new NotImplementedException();
        }
    }
}
