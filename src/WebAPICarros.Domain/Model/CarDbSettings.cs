using System;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Domain.Model
{
    public class CarDbSettings : IDatabaseSettings
    {
       public string CarroCollectionName { get; set; } = Environment.GetEnvironmentVariable("CarroCollectionName");
       public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString");
       public string DatabaseName { get; set; } = Environment.GetEnvironmentVariable("DatabaseName");

       public string UserCollectionName { get; set; } = Environment.GetEnvironmentVariable("CarroCollectionName");
       public string UserConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString");
       public string UserDatabaseName { get; set; } = Environment.GetEnvironmentVariable("DatabaseName");


    }
}
