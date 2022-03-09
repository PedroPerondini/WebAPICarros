namespace WebAPICarros.Domain.Model
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Potency { get; set; }
        public int Torque { get; set; }
        public double ZeroACem { get; set; }
        public string Yearofmanufacture { get; set; }
        public string Nationality { get; set; }
        public double EngineLiter { get; set; }
        public int FinalSpeed { get; set; }
        public double FuelConsumption { get; set; }
        public string Aspiration { get; set; }
        public string Fuel { get; set; }
    }
}
