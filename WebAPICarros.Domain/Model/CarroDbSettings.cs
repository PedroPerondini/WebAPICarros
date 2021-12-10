using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Domain.Model
{
    public class CarroDbSettings : IDatabaseSettings
    {
       public string CarroCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DatabaseName { get; set; }
    }
}
