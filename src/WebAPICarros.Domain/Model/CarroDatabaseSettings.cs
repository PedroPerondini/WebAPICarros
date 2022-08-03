using System;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Domain.Model
{
    public class CarroDatabaseSettings : ICarroDatabaseSettings
    {
        //public string CarroCollectionName { get; set; } = Environment.GetEnvironmentVariable("CarroCollectionName");
        //public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString");
        //public string DatabaseName { get; set; } = Environment.GetEnvironmentVariable("DatabaseName");

        public string CollectionName { get; set; } = "Carros";
        public string ConnectionString { get; set; } = "mongodb+srv://pedroperondini:senha123@carrosdb.8nwor.mongodb.net/CarrosDB?retryWrites=true&w=majority";
        public string DatabaseName { get; set; } = "CarrosDB";
    }
}
