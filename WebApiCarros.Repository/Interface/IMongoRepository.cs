using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Xrm.Sdk.Query;

namespace WebApiCarros.Repository.Interface
{
  public interface IMongoRepository <TDocument> where TDocument : IBaseRepository 
    {
        Task<TDocument> FindByIdAsync(string id);
        void InsertOne(TDocument document);
        Task InsertOneAsync(TDocument document);
        void InsertMany(ICollection<TDocument> documents);
        Task InsertManyAsync(ICollection<TDocument> documents);
        void ReplaceOne(TDocument document);
        Task ReplaceOneAsync(TDocument document);
        void DeleteById(string id);
        Task DeleteByIdAsync(string id);

        void DeleteMany(Expression<Func<TDocument, bool>>, Filter);


    }
}
