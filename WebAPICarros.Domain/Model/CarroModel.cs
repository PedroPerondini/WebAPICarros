using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICarros.Domain.Model
{
    public class CarroModel
    {
       public Guid Id { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Potencia { get; set; }
        public int Torque { get; set; }
        public double ZeroACem { get; set; }
        public DateTime AnoDeFabricacao { get; set; }
        public string Nacionalidade { get; set; }
    }
}
