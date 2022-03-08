using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;


namespace WebApiCarros.Repository
{
   public class MongoRepository
    {
        private readonly IMongoCollection<CarroModel> _carro;

        public MongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<CarroModel>(settings.CarroCollectionName);
        }



    }
}





 