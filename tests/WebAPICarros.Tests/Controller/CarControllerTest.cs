﻿using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Moq;
using System.Runtime.CompilerServices;
using System.Threading;
using WebAPICarros.Controllers;
using WebAPICarros.Core.Services;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Validation;
using Xunit;

namespace WebAPICarros.Tests.Controller
{
    public class CarControllerTest
    {
        private readonly CarroController _carroController;
        private readonly Mock<ICarroServices> _carroServices;
        private readonly CarFactoryTest _carFactoryTest;
        private readonly Mock<CarValidation> _carValidation;
        private readonly Mock<ValidationResult> _validationResultMock;

        public CarControllerTest()
        {
            _carroServices = new Mock<ICarroServices>();
            _carFactoryTest = new CarFactoryTest();
            _carValidation = new Mock<CarValidation>();
            _validationResultMock = new Mock<ValidationResult>();
            _carroController = new CarroController(_carroServices.Object,
                                                   _carValidation.Object);
        }

        [Fact]
        public async void Given_ValidId_When_GettingCarById_Then_ReturnSuccessStatusCode()
        {
            //Arrange
            #region Setups
            _carroServices.Setup(setup => setup.GetCarroByIdAsync(It.IsAny<int>())).ReturnsAsync(_carFactoryTest.GenerateValidCarModel());
            #endregion

            //Act
            var actionResult =  await _carroController.GetById(1);

            //Assert
            var httpResult = actionResult.Result as OkObjectResult;

            actionResult.Should().NotBeNull();
            httpResult.Should().BeOfType<OkObjectResult>();
            httpResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void Given_ValidParameters_When_InsertingCar_Then_ReturnSuccessStatusCode()
        {
            //Arrange
            #region Setups
            _validationResultMock.Setup(setup => setup.IsValid).Returns(true);
            _carValidation.Setup(setup => setup.ValidateAsync(It.IsAny<ValidationContext<CarroModel>>(), CancellationToken.None)).ReturnsAsync(_validationResultMock.Object);
            _carroServices.Setup(setup => setup.CreateCarro(It.IsAny<CarroModel>())).ReturnsAsync(_carFactoryTest.GenerateValidCarModel());
            #endregion

            //Act
            var actionResult = await _carroController.CreateCarro(_carFactoryTest.GenerateValidCarModel());

            //Assert
            var httpResult = actionResult.Result as OkObjectResult;

            actionResult.Should().NotBeNull();
            httpResult.Should().BeOfType<OkObjectResult>();
            httpResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void Given_InvalidParameters_When_InsertingCar_Then_ReturnBadRequestStatusCode()
        {
            //Arrange
            #region Setups
            _validationResultMock.Setup(setup => setup.IsValid).Returns(false);
            _carValidation.Setup(setup => setup.ValidateAsync(It.IsAny<ValidationContext<CarroModel>>(), CancellationToken.None)).ReturnsAsync(_validationResultMock.Object);
            _carroServices.Setup(setup => setup.CreateCarro(It.IsAny<CarroModel>())).ReturnsAsync(_carFactoryTest.GenerateValidCarModel());
            #endregion
            var carro = _carFactoryTest.GenerateValidCarModel();
            carro.AnoDeFabricacao = "99999";

            //Act
            var actionResult = await _carroController.CreateCarro(carro);

            //Assert
            var httpResult = actionResult.Result as BadRequestObjectResult;

            actionResult.Should().NotBeNull();
            httpResult.Should().BeOfType<BadRequestObjectResult>();
            httpResult.StatusCode.Should().Be(400);
        }
    }
}