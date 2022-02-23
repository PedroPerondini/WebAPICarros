using FluentAssertions;
using AutoBogus;
using Bogus;
using Xunit;
using WebAPICarros.Core.Services;
using Moq;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Tests.Services
{
    public class CarroServiceTest
    {
        private readonly CarrosServices _carrosServices;
        private readonly Mock<IDatabaseSettings> _databaseSettings;

        public CarroServiceTest()
        {
            _databaseSettings = new Mock<IDatabaseSettings>();

            _carrosServices = new CarrosServices
                (
                _databaseSettings.Object
                );
        }

        [Fact]
        public void Given_An_Valid_CarroId_Get_Return_Success()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _carrosServices.GetCarroById(id);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
