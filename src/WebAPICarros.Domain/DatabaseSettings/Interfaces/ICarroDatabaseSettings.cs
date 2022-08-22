namespace WebAPICarros.Domain.Model.Interfaces
{
    public interface ICarroDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
