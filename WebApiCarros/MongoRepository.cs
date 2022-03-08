using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiCarros.Repository.Interface;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebApiCarros.Repository
{
    public class MongoRepository<BaseRepository> : IMongoRepository<BaseRepository> where BaseRepository : IBaseRepository
    {
        private readonly IMongoCollection<BaseRepository> _carro;

        public MongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<BaseRepository>(settings.CarroCollectionName);
        }

        public void DeleteById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<BaseRepository>.Filter.Eq(doc => doc.Id, objectId);
             _carro.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<BaseRepository>.Filter.Eq(doc => doc.Id, objectId);
                _carro.FindOneAndDeleteAsync(filter);
            });
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
            _carro.InsertOne(document);
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
