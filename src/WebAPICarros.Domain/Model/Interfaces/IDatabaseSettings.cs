namespace WebAPICarros.Domain.Model.Interfaces
{
    public interface IDatabaseSettings
    {
        string CarroCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
