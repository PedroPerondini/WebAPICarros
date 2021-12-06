namespace WebAPICarros.Domain.Model
{
    public class CarroModel
    {
        public int Id { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Potencia { get; set; }
        public int Torque { get; set; }
        public double ZeroACem { get; set; }
        public string AnoDeFabricacao { get; set; }
        public string Nacionalidade { get; set; }
        public double LitragemMotor { get; set; }
        public int VelocidadeFinal { get; set; }
        public double ConsumoCombustivel { get; set; }
        public string Aspiracao { get; set; }
        public string Combustivel { get; set; }

    }
}
