using FluentValidation;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Domain.Validation
{
    public class CarValidation : AbstractValidator<CarroModel>
    {
        private const string _defaultInvalidMessage = "Informed parameter {0} is invalid.";

        public CarValidation()
        {
            RuleFor(car => car.AnoDeFabricacao)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.AnoDeFabricacao)))
                .Length(4)
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.AnoDeFabricacao)));

            RuleFor(car => car.Aspiracao)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Aspiracao)));

            RuleFor(car => car.Combustivel)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Combustivel)));

            RuleFor(car => car.ConsumoCombustivel)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.ConsumoCombustivel)));

            RuleFor(car => car.Fabricante)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Fabricante)));

            RuleFor(car => car.Id)
                .NotNull()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Id)));

            RuleFor(car => car.LitragemMotor)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.LitragemMotor)));

            RuleFor(car => car.Modelo)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Modelo)));

            RuleFor(car => car.Nacionalidade)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Nacionalidade)));

            RuleFor(car => car.Potencia)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Potencia)));

            RuleFor(car => car.Torque)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.Torque)));

            RuleFor(car => car.VelocidadeFinal)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.VelocidadeFinal)));

            RuleFor(car => car.ZeroACem)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(CarroModel.ZeroACem)));
        }
    }
}
