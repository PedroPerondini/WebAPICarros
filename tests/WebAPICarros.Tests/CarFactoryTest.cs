using AutoFixture;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Tests
{
    internal class CarFactoryTest
    {
        private readonly Fixture _fixture;

        public CarFactoryTest()
        {
            _fixture = new Fixture();
        }
        public CarroModel GenerateValidCarModel()
        {
            var carro = _fixture.Create<CarroModel>();
            carro.AnoDeFabricacao = "2022";
            carro.Aspiracao = "Turbo";
            carro.Combustivel = "Gasolina";
            carro.ConsumoCombustivel = 10.5;
            carro.Fabricante = "Fiat Abarth";
            carro.Id = 1;
            carro.LitragemMotor = 1.3;
            carro.Modelo = "Pulse";
            carro.Nacionalidade = "Italiano";
            carro.Potencia = 185;
            carro.Torque = 27;
            carro.VelocidadeFinal = 212;
            carro.ZeroACem = 7.8;

            return carro;

        }
    }
}
