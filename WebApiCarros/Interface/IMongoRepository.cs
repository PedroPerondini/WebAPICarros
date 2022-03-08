using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCarros.Repository.Interface
{
    public interface IMongoRepository<BaseRepository> where BaseRepository : IBaseRepository
    {
        Task<BaseRepository> FindByIdAsync(string id);
        void InsertOne(BaseRepository document);
        Task InsertOneAsync(BaseRepository document);
        void InsertMany(ICollection<BaseRepository> documents);
        Task InsertManyAsync(ICollection<BaseRepository> documents);
        void ReplaceOne(BaseRepository document);
        Task ReplaceOneAsync(BaseRepository document);
        void DeleteById(string id);
        Task DeleteByIdAsync(string id);
        Task DeleteManyAsync(Expression<Func<BaseRepository, bool>> filterExpression);





    }
}
