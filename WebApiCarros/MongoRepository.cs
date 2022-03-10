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
            return Task.Run( () => _carro.DeleteManyAsync(filterExpression));
        }

        public Task<BaseRepository> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<BaseRepository>.Filter.Eq(doc => doc.Id, objectId);
                return _carro.Find(filter).SingleOrDefaultAsync();
            });
        }

        public void InsertMany(ICollection<BaseRepository> documents)
        {
            _carro.InsertMany(documents);
        }

        public virtual async Task InsertManyAsync(ICollection<BaseRepository> documents)
        {
            await _carro.InsertManyAsync(documents);
              
        }

        public void InsertOne(BaseRepository document)
        {
            _carro.InsertOne(document);
        }

        public virtual Task InsertOneAsync(BaseRepository document)
        {
            return Task.Run( () => _carro.InsertOneAsync(document));
            
        }

        public void ReplaceOne(BaseRepository document)
        {
            var filter = Builders<BaseRepository>.Filter.Eq(doc => doc.Id, document.Id);
        }

        public virtual async Task ReplaceOneAsync(BaseRepository document)
        {
            var filter = Builders<BaseRepository>.Filter.Eq(doc => doc.Id, document.Id);
            await _carro.FindOneAndReplaceAsync(filter, document);
        }
    }
}
