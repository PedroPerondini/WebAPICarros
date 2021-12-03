using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebAPICarros.Domain.Model
{
    public class CarroModel
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("Key")]
        public Guid Key { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Potencia { get; set; }
        public int Torque { get; set; }
        public double ZeroACem { get; set; }
        public string AnoDeFabricacao { get; set; }
        public string Nacionalidade { get; set; }
        public double LitragemMotor { get; set; }
        public int VelocidadeFinal { get; set; }
        public int ConsumoCombustivel { get; set; }
        public string Aspiracao { get; set; }
        public string Combustivel { get; set; }

    }
}
