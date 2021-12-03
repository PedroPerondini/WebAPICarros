using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public DateTime AnoDeFabricacao { get; set; }
        public string Nacionalidade { get; set; }
    }
}
