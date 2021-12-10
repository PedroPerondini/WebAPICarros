using System;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Domain.Model
{
    public class CarroDbSettings : IDatabaseSettings
    {
       public string CarroCollectionName { get; set; } = Environment.GetEnvironmentVariable("CarroCollectionName");
       public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString");
       public string DatabaseName { get; set; } = Environment.GetEnvironmentVariable("DatabaseName");
    }
}
